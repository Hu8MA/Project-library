using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labrary2023.Models
{
    [Table("member_States")]
    public class member_state
    {
        public member_state()
        {
            this.Members = new HashSet<member>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idmeb_sta { get; set; }
        [Required]
        [Display(Name = "stutes of member")]
        public string value_state { get; set; }

        public virtual ICollection<member> Members { get; set; }
    }
}
