using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{
    public class Book
    {
        [FromQuery]
        public int? BookId { get; set; }
        public string? AuthorName { get; set; }
        public override string ToString()
        {
            return $"Book Id {BookId}, Author Name {AuthorName}";
        }
    }
}
