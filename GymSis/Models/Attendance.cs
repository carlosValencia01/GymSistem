using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymSis.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Gym")]
        public int GymId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime Time { get; set; }
    }
}
