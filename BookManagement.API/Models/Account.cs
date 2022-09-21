using System.ComponentModel.DataAnnotations;

namespace BookManagement.API.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, maximum: 200)]
        public int Age { get; set; }
    }
}
