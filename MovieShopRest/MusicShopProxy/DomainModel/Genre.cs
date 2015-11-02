using MovieShopDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.DomainModel
{
    [Table("Genre")]
    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        // Use this instead of HashSet for a one-to-many relation
        //public virtual List<Movie> Movies { get; set; }
    }
}
