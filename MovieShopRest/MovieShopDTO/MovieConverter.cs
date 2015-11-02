using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDAL.Models;

namespace MovieShopDTO
{
    public class MovieConverter : AbstractDtoConverter<Movie, MovieDto>
    {
        public override MovieDto Convert(Movie item)
        {
            var dto = new MovieDto()
            {
                Id = item.Id,
                PictureUrl = item.PictureURL,
                Price = item.Price,
                Rating = item.Rating,
                ReleaseDate = item.ReleaseDate,
                Title = item.Title,
                TrailerUrl = item.TrailerURL
            };
            if (item.Genres != null)
            {
                dto.Genres = new List<GenreDto>();
                foreach (var genre in item.Genres)
                {
                    dto.Genres.Add(new GenreDto()
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    });
                }
            }
            return dto;
        }
    }
}
