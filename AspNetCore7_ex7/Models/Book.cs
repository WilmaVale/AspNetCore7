namespace AspNetCore7_ex7.Models
{
    public class Book
    {
        public int? BookId { get; set; }

        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book object - book id: {BookId}, Author: {Author}";
        }
    }
}
