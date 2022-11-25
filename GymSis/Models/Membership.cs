using System.ComponentModel.DataAnnotations;

namespace GymSis.Models
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Days { get; set; }
    }
}
