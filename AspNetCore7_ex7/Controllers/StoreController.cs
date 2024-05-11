using Microsoft.AspNetCore.Mvc;

namespace AspNetCore7_ex7.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
