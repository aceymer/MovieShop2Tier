﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDTO
{
    [DataContract(IsReference = true)]
    public class MovieDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public DateTime ReleaseDate { get; set; }
        [DataMember]
        public string TrailerUrl { get; set; }
        [DataMember]
        public string PictureUrl { get; set; }
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public ICollection<GenreDto> Genres { get; set; }
    }
}
