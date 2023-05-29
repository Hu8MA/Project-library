using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labrary2023.Models
{
    [Table("members")]
    public class member
    {
        public member()
        {
            this.reservations = new HashSet<reservation>();
            this.loans = new HashSet<loan>();
            this.fine_Payments = new HashSet<fine_payment>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idmeb { get; set; }

        [Required]
        [Display(Name = "first-name")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "last-name")]
        public string Lname { get; set; }
        [Required]
        [Display(Name = "joind Date")]
        [DataType(DataType.Date)]
        public DateTime joinedDate { get; set; }

        [Required]
        [Display(Name = "stute of member")]
        public int idmeb_sta { get; set; }


        [ForeignKey("idmeb_sta")]
        public virtual member_state? Member_State { get; set; }

        public ICollection<reservation> reservations { get; set; }
        public ICollection<loan> loans { get; set; }
        public ICollection<fine_payment> fine_Payments { get; set; }
    }
}
