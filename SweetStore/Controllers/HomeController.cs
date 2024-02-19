using Microsoft.AspNetCore.Mvc;

namespace SweetStore.Controllers  
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

    }
}