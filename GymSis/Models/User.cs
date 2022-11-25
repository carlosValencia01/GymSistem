using System.ComponentModel.DataAnnotations;

namespace GymSis.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime ExpMembership { get; set; }
        public int IdGym { get; set; }
        public bool Status { get; set; }

    }
}
