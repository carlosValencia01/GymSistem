using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Gym")]
        public int IdGym { get; set; }
        [DefaultValue("true")]
        public bool Status { get; set; }

    }
}
