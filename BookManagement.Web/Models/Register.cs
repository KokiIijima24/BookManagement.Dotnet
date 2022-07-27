using System.ComponentModel.DataAnnotations;

namespace BookManagement.Web.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(40, 60)]
        public int Age { get; set; }
    }
}
