using Lab5.Entities.Enums;
using Microsoft.Extensions.DependencyModel;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; } = null!;
        public LiteraryGenreEnum Genre { get; set; }
        public string AuthorFirstName { get; set; } = null!;
        public string AuthorLastName { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public DateOnly DateOfPublication { get; set; }
        public PaperFormatEnum PaperFormat { get; set; }
        public int NumberOfPages { get; set; }
    }
}
