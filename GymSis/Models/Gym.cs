using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace GymSis.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Gym
    {
        [Key]        
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        
        public string Password { get; set; }
        public bool Status { get; set; }
        
    }
}
