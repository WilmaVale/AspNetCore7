using AspNetCore7_ex7.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore7_ex7.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        //Url: /bookstore?bookid=10&isloggedin=true
        public IActionResult Index(
            int? bookid, 
            [FromRoute]bool? isloggedin,
            Book book)
        {
            //book id should be applide
            if (!bookid.HasValue)
            { 
                return BadRequest("Book id is not supplied or empty");
            }
            if (bookid <= 0)
            {
                return BadRequest("Book ID can't be lass or equal to zero");
            }
            if (bookid > 1000)
            {
                return BadRequest("Book ID can't be more than 1000");
            }

            if (isloggedin == false)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return Content($"Book id: {bookid}, Book: {book}", "text/plain");
        }
    }
}
