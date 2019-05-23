namespace WebUI.Controllers
{
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Transformer(string number)
        {
            double result = 0;
            try
            {
                result = double.Parse(number);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View("ErrorParse");
            }
            ViewBag.num = number;
            ViewBag.result = TransformerLibrary.Transformer.TransformToWords(result);
            return View();

        }
    }
}