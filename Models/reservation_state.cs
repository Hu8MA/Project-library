using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labrary2023.Models
{
    [Table("reservation_States")]
    public class reservation_state
    {
        public reservation_state()
        {
            this.reservations = new HashSet<reservation>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idres_sta { get; set; }
        [Required]
        [Display(Name = "stutes of reservation")]
        public string value_state { get; set; }

        public virtual ICollection<reservation> reservations { get; set; }
    }
}
