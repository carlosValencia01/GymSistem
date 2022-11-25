using System.ComponentModel.DataAnnotations;

namespace GymSis.Models
{
    public class Gym
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}
