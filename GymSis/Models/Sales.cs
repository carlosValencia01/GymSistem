using System.ComponentModel.DataAnnotations;

namespace GymSis.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }

    }
}
