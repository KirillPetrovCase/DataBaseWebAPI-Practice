using System.ComponentModel.DataAnnotations;

namespace DataBaseWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required"), Range(18, 100, ErrorMessage = "Age must be in range 18 to 100")]
        public int Age { get; set; }
    }
}
