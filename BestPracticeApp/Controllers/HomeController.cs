namespace BestPracticeApp.Controllers
{
    using System.Web.Mvc;
    using ViewModels;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new BaseViewModel();
            return View(viewModel);
        }

        public ActionResult About()
        {
            var viewModel = new BaseViewModel();
            return View(viewModel);
        }

        public ActionResult Contact()
        {
            var viewModel = new BaseViewModel();
            return View(viewModel);
        }
    }
}