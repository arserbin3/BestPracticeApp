namespace BestPracticeApp.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Helpers;
    using ViewModels;

    public class BaseController : Controller
    {
        //private DosDataContext _model;
        //private MillenniumDataContext _mill;
        //private IntranetDataContext _intranet;
        //private MiniProfiler _profiler;
        //private IntraUser _intranetUser;

        /// <summary>
        /// An enumeration of action types, meant to checking the authorization of the user doing a specific action
        /// </summary>
        public enum ActionType
        {
            None,
            View,
            Edit
        }

        /*
        public DosDataContext DosModel
        {
            get
            {
                return _model ?? (_model = MiniProfilerHelper.Create<DosDataContext>());
            }
        }

        public IntranetDataContext IntranetModel
        {
            get
            {
                return _intranet ?? (_intranet = MiniProfilerHelper.Create<IntranetDataContext>());
            }
        }

        public MillenniumDataContext MillenniumModel
        {
            get
            {
                return _mill ?? (_mill = MiniProfilerHelper.Create<MillenniumDataContext>());
            }
        }

        protected MiniProfiler Profiler
        {
            get
            {
                return _profiler ?? (_profiler = MiniProfiler.Current);
            }
        }

        /// <summary>
        /// Gets the IntranetUser for the current request
        /// </summary>
        public IntraUser IntranetUser
        {
            get
            {
                return _intranetUser ?? (_intranetUser = IntranetModel.GetUserByUsername(User.Identity.Name));
            }
        }
        */

        /// <summary>
        /// Gets a value indicating whether debug mode is enabled
        /// </summary>
        public bool IsDebuggingEnabled
        {
            // TODO: consider cacheing this like the other properties
            get
            {
                return ControllerContext.HttpContext.IsDebuggingEnabled;
            }
        }

        /*
        /// <summary>
        /// Returns whether the current user is authorized to access the given form
        /// </summary>
        /// <param name="form">Form to check</param>
        /// <param name="action">The action the user is attempting to get authorization for</param>
        public bool IsAuthorized(Form form, ActionType action = ActionType.None)
        {
            // check if this form belongs to the same division as the user
            // TODO: handle null form DivisionID - who gets access then?
            var sameDivision = (
                IntranetUser.dept != null
                && form.Division != null
                && IntranetUser.dept.Trim() == form.Division.Code);

            // get the roles for the given action
            var roles = "";
            switch (action)
            {
                case ActionType.View:
                    roles +=
                        Constants.Roles.ViewAll
                        + (sameDivision ? (", " + Constants.Roles.ViewDivision) : "");
                    break;

                case ActionType.Edit:
                    roles +=
                        Constants.Roles.EditAll
                        + (sameDivision ? (", " + Constants.Roles.EditDivision) : "");
                    break;
            }

            // split roles into a list and remove blank ones
            var roleList = roles
                .Split(',')
                .Select(x => (x ?? "")
                .Trim())
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .ToList();

            // parse the explicit access list (of user names), if it exists
            var userList = (form.AccessList ?? "")
                .Split(',')
                .Select(x => (x ?? "").ToLower().Trim())
                .ToList();
            userList.RemoveAll(String.IsNullOrWhiteSpace);

            // return whether user has a matching role or user name
            return
                (roleList.Any(x => User.IsInRole(x))
                || (!String.IsNullOrWhiteSpace(User.Identity.Name)
                    && userList.Contains(User.Identity.Name.ToLower())));
        }

        /// <summary>
        /// Returns whether the current user is authorized to access the given form
        /// </summary>
        /// <param name="formID">Form ID to check</param>
        /// <param name="action">The action the user is attempting to get authorization for</param>
        protected bool IsAuthorized(long formID, ActionType action = ActionType.None)
        {
            var form = DosModel.GetFormByID(formID);
            return IsAuthorized(form, action);
        }
        */

        /// <summary>
        /// Displays a not authorized message.
        /// </summary>
        public ViewResult NotAuthorized(string message, string currentTab = null)
        {
            var viewModel = new BaseViewModel
            {
                DisplayMessage = message ?? Constants.NotAuthorized.General,
                PageTitle = "Not Authorized",
                CurrentTab = currentTab
            };

            return View("NotAuthorized", viewModel);
        }

        /// <summary>
        /// Pass through property to make UpdateModel public.
        /// </summary>
        /// <typeparam name="T">any class normally useable by UpdateModel</typeparam>
        public void PublicUpdateModel<T>(T model, IValueProvider valueProvider) where T : class
        {
            UpdateModel(model, valueProvider);
        }
    }
}