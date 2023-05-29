using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labrary2023.Models
{
    [Table("book")]

    public class book
    {
        public book()
        {
            this.book_author =new HashSet<book_author>();
            this.reservations =new HashSet<reservation>();
            this.loans =new HashSet<loan>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idbook { get; set; }

        [Required(ErrorMessage ="jfuf")]
        [Display(Name ="Title Book")]
        
        public string title { get; set; }


        [Required]
        [Display(Name = "publish Date of Book")]
        public DateTime publish { get; set; }


        [Required]
        [Display(Name = "Number copis of Book")]
        public int copies { get; set; }


      
        [Display(Name = "Category of Book")]
        public int idcat { get; set; }
         


        [ForeignKey("idcat")]
        public virtual category? Category {  get; set; }


        public ICollection<book_author> book_author { get; set; }
        public ICollection<reservation> reservations { get; set; }
        public ICollection<loan> loans { get; set; }

    }
}
