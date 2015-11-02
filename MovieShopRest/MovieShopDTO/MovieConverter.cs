using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDAL.Models;

namespace MovieShopDTO
{
    public class MovieConverter
    {
        public static IEnumerable<MovieDTO> ConvertToDto(IEnumerable<Movie> movies)
        {
            //AutoMapper.CreateMap<Movie, MovieDTO>();
            return movies.Select(x => new MovieDTO()
            {
                Id = x.Id,
                PictureURL =  x.PictureURL,
                Price = x.Price,
                Rating = x.Rating,
                ReleaseDate = x.ReleaseDate,
                Title = x.Title,
                TrailerURL = x.TrailerURL,
                Genres = x.Genres.Select(y => new GenreDTO()
                {
                   Name = y.Name,
                   Id = y.Id
                }).ToList()
            }).ToList();
        }
    }
}
