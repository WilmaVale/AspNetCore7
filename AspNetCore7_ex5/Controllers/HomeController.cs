using AspNetCore7_ex5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore7_ex5.Controllers
{
    public class HomeController: Controller
    {
        // puoi aggiungere più route per avere lo stesso comportamento
        [Route("method1")]
        [Route("method2")]
        public string Method1()
        {
            
            return "Hello from Method1";
        }

        [Route("home")]
        [Route("/")]
        public ContentResult Index()
           // public string Index()
        {
            // EX 2 SEZIONE 6: Controllers & IActionResult
            // cambia il tipo di ritorno a ContentResult

            //return "Hello from Index";

            // se vogliamo farlo noi "a mano"
            //return new ContentResult()
            //{ 
            //    Content= "Hello from index",
            //    ContentType = "text/plain"
            //};

            // possiamo invece ereditarlo da Microsoft.AspNetCore.Mvc.Controller
            //return Content("Hello from index", "text/plain");
            return Content("<h1>Hello</h1> <h2>from index</h2>", "text/html");
        }

        [Route("about")]
        // EX 3 SEZIONE 6: Controllers & IActionResult
        // cambia il tipo di ritorno a Json
        public JsonResult About()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mario",
                LastName = "Rossi",
                Age = 30
            };
            //return "Hello from About";
            //return new JsonResult(person);//puoi scriverlo così
            return Json(person);// oppure così
        }

        // EX 4 SEZIONE 6: Controllers & IActionResult
        // mandare un file:
        // - VirtualFileResult
        // - PhysicalFileResult
        // - FileContentResult
        [Route("download-file")]
        public VirtualFileResult DownloadFile()
        {
            // NB: ricorda di mettere app.UseStaticFiles(); in Program.cs
            // di default i file li cerca nel folder "wwwroot", il path parte da lì
            //return new VirtualFileResult("/sample.pdf", "application/pdf");
            return File("/sample.pdf", "application/pdf");
        }

        [Route("download-file2")]
        public PhysicalFileResult DownloadFile2()
        {
            // devi mettere il full-path
            //return new PhysicalFileResult(@"C:\Users\WilmaValentino\source\repos\AspNetCore7_exercises\AspNetCore7_ex5\wwwroot\sample.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\WilmaValentino\source\repos\AspNetCore7_exercises\AspNetCore7_ex5\wwwroot\sample.pdf", "application/pdf");
        }

        [Route("download-file3")]
        public FileContentResult DownloadFile3()
        {
            byte[] fileArrayBytes= System.IO.File.ReadAllBytes(@"C:\Users\WilmaValentino\source\repos\AspNetCore7_exercises\AspNetCore7_ex5\wwwroot\sample.pdf");

            //return new FileContentResult(fileArrayBytes, "application/pdf");
            return File(fileArrayBytes, "application/pdf");
        }
    }
}
