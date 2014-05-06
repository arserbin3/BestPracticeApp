namespace BestPracticeApp.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.UI.WebControls;

    // TODO: consider splitting AjaxHelpers into their own class
    /// <summary>
    /// This class adds helper extensions to both HtmlHelper and AjaxHelper, for use in razor views.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        // TODO: fill it the parameter info using descriptions from the normal ActionLink helper
        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, and a prepended icon.
        /// </summary>
        public static MvcHtmlString IconActionLink(this AjaxHelper helper, string icon, string text, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var builder = new TagBuilder("i");
            builder.MergeAttribute("class", icon);
            var link = helper.ActionLink("[replaceme] " + text, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString()));
        }

        // TODO: fill it the parameter info using descriptions from the normal ActionLink helper
        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, and a prepended icon.
        /// </summary>
        public static MvcHtmlString IconActionLink(this HtmlHelper helper, string icon, string text, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var test = EnumerationHelper.GetEnumDescription(Glyphicon.Plane);
            var builder = new TagBuilder("i");
            builder.MergeAttribute("class", icon);
            var link = helper.ActionLink("[replaceme] " + text, actionName, controllerName, routeValues, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString()));
        }

        // TODO: fill it the parameter info using descriptions from the normal ActionLink helper
        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, and a prepended icon.
        /// </summary>
        public static MvcHtmlString IconActionLink(this AjaxHelper helper, Glyphicon icon, string text, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var iconString = String.Format("glyphicon glyphicon-{0}", EnumerationHelper.GetEnumDescription(Glyphicon.Plane));
            return IconActionLink(helper, iconString, text, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
        }

        // TODO: fill it the parameter info using descriptions from the normal ActionLink helper
        /// <summary>
        /// Returns an anchor element (a element) that contains the virtual path of the specified action, and a prepended icon.
        /// </summary>
        public static MvcHtmlString IconActionLink(this HtmlHelper helper, Glyphicon icon, string text, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var iconString = String.Format("glyphicon glyphicon-{0}", EnumerationHelper.GetEnumDescription(Glyphicon.Plane));
            return IconActionLink(helper, iconString, text, actionName, controllerName, routeValues, htmlAttributes);
        }

        // TODO: this probably belongs in its own class
        public enum Glyphicon
        {
            [Description("asterisk")]
            Asterisk,

            [Description("plus")]
            Plus,

            [Description("euro")]
            Euro,

            [Description("minus")]
            Minus,

            [Description("cloud")]
            Cloud,

            [Description("envelope")]
            Envelope,

            [Description("pencil")]
            Pencil,

            [Description("glass")]
            Glass,

            [Description("music")]
            Music,

            [Description("search")]
            Search,

            [Description("heart")]
            Heart,

            [Description("star")]
            Star,

            [Description("star-empty")]
            StarEmpty,

            [Description("user")]
            User,

            [Description("film")]
            Film,

            [Description("th-large")]
            ThLarge,

            [Description("th")]
            Th,

            [Description("th-list")]
            ThList,

            [Description("ok")]
            Ok,

            [Description("remove")]
            Remove,

            [Description("zoom-in")]
            ZoomIn,

            [Description("zoom-out")]
            ZoomOut,

            [Description("off")]
            Off,

            [Description("signal")]
            Signal,

            [Description("cog")]
            Cog,

            [Description("trash")]
            Trash,

            [Description("home")]
            Home,

            [Description("file")]
            File,

            [Description("time")]
            Time,

            [Description("road")]
            Road,

            [Description("download-alt")]
            DownloadAlt,

            [Description("download")]
            Download,

            [Description("upload")]
            Upload,

            [Description("inbox")]
            Inbox,

            [Description("play-circle")]
            PlayCircle,

            [Description("repeat")]
            Repeat,

            [Description("refresh")]
            Refresh,

            [Description("list-alt")]
            ListAlt,

            [Description("lock")]
            Lock,

            [Description("flag")]
            Flag,

            [Description("headphones")]
            Headphones,

            [Description("volume-off")]
            VolumeOff,

            [Description("volume-down")]
            VolumeDown,

            [Description("volume-up")]
            VolumeUp,

            [Description("qrcode")]
            Qrcode,

            [Description("barcode")]
            Barcode,

            [Description("tag")]
            Tag,

            [Description("tags")]
            Tags,

            [Description("book")]
            Book,

            [Description("bookmark")]
            Bookmark,

            [Description("print")]
            Print,

            [Description("camera")]
            Camera,

            [Description("font")]
            Font,

            [Description("bold")]
            Bold,

            [Description("italic")]
            Italic,

            [Description("text-height")]
            TextHeight,

            [Description("text-width")]
            TextWidth,

            [Description("align-left")]
            AlignLeft,

            [Description("align-center")]
            AlignCenter,

            [Description("align-right")]
            AlignRight,

            [Description("align-justify")]
            AlignJustify,

            [Description("list")]
            List,

            [Description("indent-left")]
            IndentLeft,

            [Description("indent-right")]
            IndentRight,

            [Description("facetime-video")]
            FacetimeVideo,

            [Description("picture")]
            Picture,

            [Description("map-marker")]
            MapMarker,

            [Description("adjust")]
            Adjust,

            [Description("tint")]
            Tint,

            [Description("edit")]
            Edit,

            [Description("share")]
            Share,

            [Description("check")]
            Check,

            [Description("move")]
            Move,

            [Description("step-backward")]
            StepBackward,

            [Description("fast-backward")]
            FastBackward,

            [Description("backward")]
            Backward,

            [Description("play")]
            Play,

            [Description("pause")]
            Pause,

            [Description("stop")]
            Stop,

            [Description("forward")]
            Forward,

            [Description("fast-forward")]
            FastForward,

            [Description("step-forward")]
            StepForward,

            [Description("eject")]
            Eject,

            [Description("chevron-left")]
            ChevronLeft,

            [Description("chevron-right")]
            ChevronRight,

            [Description("plus-sign")]
            PlusSign,

            [Description("minus-sign")]
            MinusSign,

            [Description("remove-sign")]
            RemoveSign,

            [Description("ok-sign")]
            OkSign,

            [Description("question-sign")]
            QuestionSign,

            [Description("info-sign")]
            InfoSign,

            [Description("screenshot")]
            Screenshot,

            [Description("remove-circle")]
            RemoveCircle,

            [Description("ok-circle")]
            OkCircle,

            [Description("ban-circle")]
            BanCircle,

            [Description("arrow-left")]
            ArrowLeft,

            [Description("arrow-right")]
            ArrowRight,

            [Description("arrow-up")]
            ArrowUp,

            [Description("arrow-down")]
            ArrowDown,

            [Description("share-alt")]
            ShareAlt,

            [Description("resize-full")]
            ResizeFull,

            [Description("resize-small")]
            ResizeSmall,

            [Description("exclamation-sign")]
            ExclamationSign,

            [Description("gift")]
            Gift,

            [Description("leaf")]
            Leaf,

            [Description("fire")]
            Fire,

            [Description("eye-open")]
            EyeOpen,

            [Description("eye-close")]
            EyeClose,

            [Description("warning-sign")]
            WarningSign,

            [Description("plane")]
            Plane,

            [Description("calendar")]
            Calendar,

            [Description("random")]
            Random,

            [Description("comment")]
            Comment,

            [Description("magnet")]
            Magnet,

            [Description("chevron-up")]
            ChevronUp,

            [Description("chevron-down")]
            ChevronDown,

            [Description("retweet")]
            Retweet,

            [Description("shopping-cart")]
            ShoppingCart,

            [Description("folder-close")]
            FolderClose,

            [Description("folder-open")]
            FolderOpen,

            [Description("resize-vertical")]
            ResizeVertical,

            [Description("resize-horizontal")]
            ResizeHorizontal,

            [Description("hdd")]
            Hdd,

            [Description("bullhorn")]
            Bullhorn,

            [Description("bell")]
            Bell,

            [Description("certificate")]
            Certificate,

            [Description("thumbs-up")]
            ThumbsUp,

            [Description("thumbs-down")]
            ThumbsDown,

            [Description("hand-right")]
            HandRight,

            [Description("hand-left")]
            HandLeft,

            [Description("hand-up")]
            HandUp,

            [Description("hand-down")]
            HandDown,

            [Description("circle-arrow-right")]
            CircleArrowRight,

            [Description("circle-arrow-left")]
            CircleArrowLeft,

            [Description("circle-arrow-up")]
            CircleArrowUp,

            [Description("circle-arrow-down")]
            CircleArrowDown,

            [Description("globe")]
            Globe,

            [Description("wrench")]
            Wrench,

            [Description("tasks")]
            Tasks,

            [Description("filter")]
            Filter,

            [Description("briefcase")]
            Briefcase,

            [Description("fullscreen")]
            Fullscreen,

            [Description("dashboard")]
            Dashboard,

            [Description("paperclip")]
            Paperclip,

            [Description("heart-empty")]
            HeartEmpty,

            [Description("link")]
            Link,

            [Description("phone")]
            Phone,

            [Description("pushpin")]
            Pushpin,

            [Description("usd")]
            Usd,

            [Description("gbp")]
            Gbp,

            [Description("sort")]
            Sort,

            [Description("sort-by-alphabet")]
            SortByAlphabet,

            [Description("sort-by-alphabet-alt")]
            SortByAlphabetAlt,

            [Description("sort-by-order")]
            SortByOrder,

            [Description("sort-by-order-alt")]
            SortByOrderAlt,

            [Description("sort-by-attributes")]
            SortByAttributes,

            [Description("sort-by-attributes-alt")]
            SortByAttributesAlt,

            [Description("unchecked")]
            Unchecked,

            [Description("expand")]
            Expand,

            [Description("collapse-down")]
            CollapseDown,

            [Description("collapse-up")]
            CollapseUp,

            [Description("log-in")]
            LogIn,

            [Description("flash")]
            Flash,

            [Description("log-out")]
            LogOut,

            [Description("new-window")]
            NewWindow,

            [Description("record")]
            Record,

            [Description("save")]
            Save,

            [Description("open")]
            Open,

            [Description("saved")]
            Saved,

            [Description("import")]
            Import,

            [Description("export")]
            Export,

            [Description("send")]
            Send,

            [Description("floppy-disk")]
            FloppyDisk,

            [Description("floppy-saved")]
            FloppySaved,

            [Description("floppy-remove")]
            FloppyRemove,

            [Description("floppy-save")]
            FloppySave,

            [Description("floppy-open")]
            FloppyOpen,

            [Description("credit-card")]
            CreditCard,

            [Description("transfer")]
            Transfer,

            [Description("cutlery")]
            Cutlery,

            [Description("header")]
            Header,

            [Description("compressed")]
            Compressed,

            [Description("earphone")]
            Earphone,

            [Description("phone-alt")]
            PhoneAlt,

            [Description("tower")]
            Tower,

            [Description("stats")]
            Stats,

            [Description("sd-video")]
            SdVideo,

            [Description("hd-video")]
            HdVideo,

            [Description("subtitles")]
            Subtitles,

            [Description("sound-stereo")]
            SoundStereo,

            [Description("sound-dolby")]
            SoundDolby,

            [Description("sound-5-1")]
            Sound51,

            [Description("sound-6-1")]
            Sound61,

            [Description("sound-7-1")]
            Sound71,

            [Description("copyright-mark")]
            CopyrightMark,

            [Description("registration-mark")]
            RegistrationMark,

            [Description("cloud-download")]
            CloudDownload,

            [Description("cloud-upload")]
            CloudUpload,

            [Description("tree-conifer")]
            TreeConifer,

            [Description("tree-deciduous")]
            TreeDeciduous
        }
    }
}