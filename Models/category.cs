using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labrary2023.Models
{
    [Table("category")]
    public class category
    {
        public category()
        {
            this.books = new HashSet<book>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "name Category")]
        public int idcat { get; set; }

  
        [Required]
        [Display(Name = "name author")]
        public string name { get; set; }

        public ICollection<book> books { get; set; }


    }
}
