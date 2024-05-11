using Microsoft.AspNetCore.Mvc;

namespace AspNetCore7_ex6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                //return Content("Book ID is not supplied");

                // invece che settare lo StatusCode puoi usare una classe già fatta, ovvero BadRequestResult
                //return new BadRequestResult();

                // oppure puoi usare il medoto
                return BadRequest("Book ID is not supplied");
            }

            // book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;
                //return Content("Book ID is not empty");

                return BadRequest("Book ID is not empty");
            }

            // book ID should be between 1 to 1000
            int bookID = Convert.ToUInt16(Request.Query["bookid"]);
            if (bookID <=0)
            {
                //Response.StatusCode = 400;
                //return Content("Book ID can't be lass or equal to zero");

                return BadRequest("Book ID can't be lass or equal to zero");
            }
            if (bookID > 1000)
            {
                //Response.StatusCode = 400;
                //return Content("Book ID can't be more than 1000");

                return BadRequest("Book ID can't be more than 1000");
            }

            //isloggedin should be applied
            if (!Request.Query.ContainsKey("isloggedin"))
            {
                //Response.StatusCode = 400;
                //return Content("isloggedin is not supplied");

                return BadRequest("isloggedin is not supplied");
            }

            if (!Convert.ToBoolean(Request.Query["isloggedin"]))
            {
                //Response.StatusCode = 401;
                //return Content("User must be authenticated");

                //return Unauthorized("User must be authenticated");

                // puoi anche usare
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            //return File("/sample.pdf", "application/pdf");

            // ritorna un 302 con chiamata al nuovo url
            //return new RedirectToActionResult("Books", "StoreController", new { });
            // se aggiungi true alla fine, non darà 302 ma 301 ovvero "Moved Permanently"
            //return new RedirectToActionResult("Books", "StoreController", new { }, true);

            // invece che RedirectToActionResult puoi usare:
            //return RedirectToAction("Books", "StoreController", new { id = bookID });
            // 301 ovvero "Moved Permanently"
            //return RedirectToActionPermanent("Books", "StoreController", new { id = bookID });

            // puoi chiamare l'url solo della tua stessa applicazione, es. non puoi chiamare google con questa chiamata
            // devi dargli l'url, es. qui sotto
            //return new LocalRedirectResult($"store/books/{bookID}");
            //return LocalRedirect($"store/books/{bookID}");

            // per moved permanently
            //return new LocalRedirectResult($"store/books/{bookID}", true);
            return LocalRedirectPermanent($"store/books/{bookID}");
        }
    }
}
