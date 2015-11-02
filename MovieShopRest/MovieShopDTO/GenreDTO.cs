using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MovieDTO> Movies { get; set; }

    }
}
