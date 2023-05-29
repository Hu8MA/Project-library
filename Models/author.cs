using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Labrary2023.Models
{
    [Table("authors")]

    public class author
    {
        public author()
        {
            this.book_authors = new HashSet<book_author>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAuthor { get; set; }
        [Required]
        [Display(Name = "First-name")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "last-name")]
        public string Lname { get; set; }


       public ICollection<book_author> book_authors { get; set; }
    }
}
