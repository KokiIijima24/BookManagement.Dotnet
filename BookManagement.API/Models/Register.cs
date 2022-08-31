using System.ComponentModel.DataAnnotations;

namespace BookManagement.API.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 60)]
        public int Age { get; set; }
    }
}
