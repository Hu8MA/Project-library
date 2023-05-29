using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labrary2023.Models
{
    [Table("fine_Payments")]
    public class fine_payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int idfi_pa { get; set; }
        [Required]
        [Display(Name ="name member")]
        public int idmeb { get; set; }
        [Required]
        [Display(Name = "Date Payment")]
        [DataType(DataType.Date)]
        public DateTime DatePay { get; set; }
        [Required]
        [Display(Name = "Amount Payment")]
        public int payamount { get; set; }

        [ForeignKey("idmeb")]
        public virtual member? singelmember { get; set; }
    }
}
