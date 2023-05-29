using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Labrary2023.Models
{
    [Table("fines")]
    public class fine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idfn { get; set; }

        [Required]
        [Display(Name = "name of member")]
        public int idlon { get; set; }

        [Required]
        [Display(Name = "Date of fine")]
        [DataType(DataType.Date)]
        public DateTime fine_Date { get; set; }

        [Required]
        [Display(Name = "amount of fine")]
        public int fine_amount { get; set; }


        [ForeignKey("idlon")]
        public virtual loan? Loan { get; set; }
    }
}
