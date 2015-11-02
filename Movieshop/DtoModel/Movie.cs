using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string TrailerUrl { get; set; }
        public string PictureUrl { get; set; }
        public int Rating { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
