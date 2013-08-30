using Ninject.Extensions.UXRiskLogger;
using System.Web.Mvc;

namespace MvcAzureLoggingDemo.Controllers
{
    public class HomeController : Controller
    {
        public ILogger Logger { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            Logger.Info("Hei", 1.0, UnitType.count, "123asd");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
