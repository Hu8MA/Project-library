using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Labrary2023.Models
{
    [Table("book_Authors")]
    public class book_author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idBo_Au { get; set; }


        [Required]
        [Display(Name = "name book")]
        public int idbook { get; set; }


        [Required]
        [Display(Name = "name author")]
        public int idAuthor{ get; set; }





        [ForeignKey("idbook")]
        public virtual book? Book { get; set; }

        [ForeignKey("idAuthor")]
        public virtual author? Author { get; set; }
    }
}
