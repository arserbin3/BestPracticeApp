namespace BestPracticeApp.Controllers
{
    using System.Web.Mvc;
    using ViewModels;

    public class SetupController : Controller
    {
        // GET: /Setup/
        public ActionResult Index()
        {
            var viewModel = new BaseViewModel();
            return View(viewModel);
        }
    }
}