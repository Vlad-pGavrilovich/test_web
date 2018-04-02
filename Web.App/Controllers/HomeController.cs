using System.Web.Mvc;
using Web.App.ViewModels.Products;

namespace Web.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ProductComplexViewModel());
        }
    }
}
