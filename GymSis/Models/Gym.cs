using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymSis.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Gym
    {
        [Key]        
        public int Id { get; set; }
        //[Remote(action: "VerifyEmail", controller: "Access")]
        //Este hacerlo unique
        public string Email { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Telefono")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
        [NotMapped] // Does not effect with your database
        [Compare("Password")]
        [DisplayName("Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

        [DefaultValue("true")]
        public bool Status { get; set; }
        
    }
}
