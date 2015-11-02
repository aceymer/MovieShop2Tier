using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string TrailerURL { get; set; }
        public string PictureURL { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<GenreDTO> Genres { get; set; }
    }
}
