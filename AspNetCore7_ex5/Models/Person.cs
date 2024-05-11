namespace AspNetCore7_ex5.Models
{
    // EX 3 SEZIONE 6: Controllers & IActionResult
    // cambia il tipo di ritorno a Json
    public class Person
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

    }
}
