namespace BestPracticeApp.ViewModels
{
    using System;
    using System.Linq;
    using System.Web;

    public class BaseViewModel
    {
        public BaseViewModel()
        {
            CurrentTab = "Home";
        }

        public BaseViewModel(string currentTab)
        {
            CurrentTab = currentTab;
        }

        public string PageTitle { get; set; }

        public string CurrentTab { get; set; }

        public string DisplayMessage { get; set; }

        public bool IsAdmin
        {
            get
            {
                // get the list of valid admin roles
                var adminRoles =
                    Constants.Roles.Admin.Split(',')
                        .Select(x => (x ?? "").Trim())
                        .Where(x => !String.IsNullOrWhiteSpace(x))
                        .ToList();

                // return true if the user has any of the admin roles
                return adminRoles.Any(x => HttpContext.Current.User.IsInRole(x));
            }
        }

        /// <summary>
        /// Returns a CSS class for whether the given tab name equals the current tab.
        /// </summary>
        /// <param name="tabName">name of the tab to check</param>
        /// <returns>active if the tab is the current tab, empty string if not.</returns>
        public string TabClass(string tabName)
        {
            return (CurrentTab == tabName
                ? "active"
                : "");
        }
    }
}