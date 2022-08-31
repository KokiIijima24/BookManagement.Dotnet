using System.ComponentModel.DataAnnotations;

namespace BookManagement.API.Models
{
    public class Book
    {
        [Key] public string ISBN { get; set; }
        public string Title { get; set; }
    }
}
