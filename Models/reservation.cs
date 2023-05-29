using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labrary2023.Models
{
    [Table("reservations")]
    public class reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idres { get; set; }


        [Required]
        [Display(Name = "name of book")]
        public int idbook { get; set; }
        [Required]
        [Display(Name = "name of member")]
        public int idmeb { get; set; }

        [Required]
        [Display(Name = "reservation stutes")]
        public int reservation_states_id { get; set; }
        [Required]
        [Display(Name = "reservation Date")]
        [DataType(DataType.Date)]
        public DateTime reservation_date { get; set; }

        [ForeignKey("idbook")]
        public virtual book? Book { get; set; }
        [ForeignKey("idmeb")]
        public virtual member?  Member { get; set; }  
        
        [ForeignKey("reservation_states_id")]
        public virtual reservation_state? reservation_states { get; set; }
        

    }
}
