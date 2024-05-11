using AspNetCore7_ex8.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore7_ex8.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("register")]
        public IActionResult Index(Person person)
        {
            // nella classe Person abbiamo aggiunto [Required]
            // ora vediamo come controllare che non ci siano errori in una request
            if (!ModelState.IsValid)
            {
                // se arriviamo qui significa che ALMENO un errore c'è stato

                //List<string> errorsList = new();

                // cicliamo su tutti i campi per vedere quali hanno problemi
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}
                List<string> errorsList = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage)
                    .ToList();

                string errorsRequest = string.Join("\n", errorsList);
                return BadRequest(errorsRequest);
            }
            return Content($"{person}");
        }
    }
}
