using Microsoft.AspNetCore.Mvc;

namespace AspNetCore7_ex6.Controllers
{
    // ex 2: redirect
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            return Content($"Book store id: {id}", "plain/text");
        }
    }
}
