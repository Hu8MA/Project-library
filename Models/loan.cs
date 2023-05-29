using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labrary2023.Models
{
    [Table("loans")]
    public class loan
    {
        public loan()
        {
            this.Fine = new HashSet<fine>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idlo { get; set; }

        [Required]
        [Display(Name = "name book")]
        public int idbook { get; set; }

        [Required]
        [Display(Name = "name member")]
        public int idmeb { get; set; }

        [Required]
        [Display(Name = "loan Date")]
        public DateTime loan_date { get; set; }
        [Required]
        [Display(Name = "return Date")]
        public DateTime return_date { get; set; }

        [ForeignKey("idbook")]
        public virtual book? Book { get; set; }

        [ForeignKey("idmeb")]
        public virtual member? Member { get; set; }


        public virtual ICollection<fine> Fine { get; set; }
    }
}
