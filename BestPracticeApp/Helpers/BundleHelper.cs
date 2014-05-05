namespace BestPracticeApp.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.Optimization;
    using dotless.Core;
    using dotless.Core.Abstractions;
    using dotless.Core.Importers;
    using dotless.Core.Input;
    using dotless.Core.Loggers;
    using dotless.Core.Parser;

    /// <summary>
    /// This class implements bundling for file types not supported by default. Currently that includes .less CSS files.
    /// </summary>
    public static class BundleHelper
    {
        internal class LessBundle : StyleBundle
        {
            public LessBundle(string virtualPath)
                : base(virtualPath)
            {
                // inject LessTransform to the beginning of the Transforms
                Transforms.Insert(0, new LessTransform());
            }

            public LessBundle(string virtualPath, string cdnPath)
                : base(virtualPath, cdnPath)
            {
                // inject LessTransform to the beginning of the Transforms
                Transforms.Insert(0, new LessTransform());
            }
        }

        // TODO: speed improvement - consider not parsing any CSS files that are not LESS
        // TODO: verify that this still works for nested @imports
        internal class LessTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse bundle)
            {
                if (context == null)
                    throw new ArgumentNullException("context");

                if (bundle == null)
                    throw new ArgumentNullException("bundle");

                context.HttpContext.Response.Cache.SetLastModifiedFromFileDependencies();

                // initialize variables
                var lessParser = new Parser();
                ILessEngine lessEngine = CreateLessEngine(lessParser);
                var content = new StringBuilder(bundle.Content.Length);
                var bundleFiles = new List<BundleFile>();

                foreach (var bundleFile in bundle.Files)
                {
                    bundleFiles.Add(bundleFile);

                    // set the current file path for all imports to use as the working directory
                    SetCurrentFilePath(lessParser, bundleFile.IncludedVirtualPath);

                    using (var reader = new StreamReader(bundleFile.VirtualFile.Open()))
                    {
                        // read in the LESS file
                        string source = reader.ReadToEnd();

                        // parse the LESS to CSS
                        content.Append(lessEngine.TransformToCss(source, bundleFile.IncludedVirtualPath));
                        content.AppendLine();

                        // add all import files to the list of bundleFiles
                        ////bundleFiles.AddRange(GetFileDependencies(lessParser));
                    }
                }

                // include imports in bundle files to register cache dependencies
                if (BundleTable.EnableOptimizations)
                    bundle.Files = bundleFiles.Distinct();

                bundle.ContentType = "text/css";
                bundle.Content = content.ToString();
            }

            /// <summary>
            /// Creates an instance of LESS engine.
            /// </summary>
            /// <param name="lessParser">The LESS parser.</param>
            private ILessEngine CreateLessEngine(Parser lessParser)
            {
                var logger = new AspNetTraceLogger(LogLevel.Debug, new Http());
                return new LessEngine(lessParser, logger, true, false);
            }

            // TODO: this is not currently working and may be unnecessary.
            /// <summary>
            /// Gets the file dependencies (@imports) of the LESS file being parsed.
            /// </summary>
            /// <param name="lessParser">The LESS parser.</param>
            /// <returns>An array of file references to the dependent file references.</returns>
            private static IEnumerable<BundleFile> GetFileDependencies(Parser lessParser)
            {
                foreach (var importPath in lessParser.Importer.Imports)
                {
                    var fileName = VirtualPathUtility.Combine(lessParser.FileName, importPath);
                    var file = BundleTable.VirtualPathProvider.GetFile("~/Content/test2.less");

                    yield return new BundleFile(fileName, file);
                }

                lessParser.Importer.Imports.Clear();
            }

            /// <summary>
            /// Informs the LESS parser about the path to the currently processed file.
            /// This is done by using a custom <see cref="IPathResolver"/> implementation.
            /// </summary>
            /// <param name="lessParser">The LESS parser.</param>
            /// <param name="currentFilePath">The path to the currently processed file.</param>
            private static void SetCurrentFilePath(Parser lessParser, string currentFilePath)
            {
                var importer = lessParser.Importer as Importer;

                if (importer == null)
                    throw new InvalidOperationException("Unexpected dotless importer type.");

                var fileReader = importer.FileReader as FileReader;

                if (fileReader != null && fileReader.PathResolver is ImportedFilePathResolver)
                    return;

                fileReader = new FileReader(new ImportedFilePathResolver(currentFilePath));
                importer.FileReader = fileReader;
            }
        }

        public class ImportedFilePathResolver : IPathResolver
        {
            private string _currentFileDirectory;
            private string _currentFilePath;

            public ImportedFilePathResolver(string currentFilePath)
            {
                if (String.IsNullOrEmpty(currentFilePath))
                    throw new ArgumentNullException("currentFilePath");

                CurrentFilePath = currentFilePath;
            }

            /// <summary>
            /// Gets or sets the path to the currently processed file.
            /// </summary>
            public string CurrentFilePath
            {
                get
                {
                    return _currentFilePath;
                }

                set
                {
                    var path = GetFullPath(value);
                    _currentFilePath = path;
                    _currentFileDirectory = Path.GetDirectoryName(path);
                }
            }

            /// <summary>
            /// Returns the absolute path for the specified imported file path.
            /// </summary>
            /// <param name="filePath">The imported file path.</param>
            public string GetFullPath(string filePath)
            {
                if (filePath.StartsWith("~"))
                    filePath = VirtualPathUtility.ToAbsolute(filePath);

                if (filePath.StartsWith("/"))
                    filePath = HostingEnvironment.MapPath(filePath);
                else if (!Path.IsPathRooted(filePath))
                    filePath = Path.GetFullPath(Path.Combine(_currentFileDirectory, filePath));

                return filePath;
            }
        }
    }
}