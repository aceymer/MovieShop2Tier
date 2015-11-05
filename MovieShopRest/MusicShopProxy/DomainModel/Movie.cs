using MovieShopDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MovieShopDAL.Models
{
    //[DataContract(IsReference = true)]
    [Table("Movie")]
    public class Movie
    {
        public Movie() { }
        [Key]
        //[DataMember]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        [StringLength(50)]
        //[DataMember]
        public string Title { get; set; }
        [Range(1, 9000)]
        [DataType("number")]
        [Required]
        //[DataMember]
        public int Price { get; set; }
        [DataType("date")]
        [Display(Name = "Release Date")]
        [Required]
        //[DataMember]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Trailer Link")]
        [Required]
        //[DataMember]
        public string TrailerURL { get; set; }
        [Display(Name = "Picture Link")]
        [Required]
        ///[DataMember]
        public string PictureURL { get; set; }
        [Range(0, 5)]
        [Required]
        //[DataMember]
        public int Rating { get; set; }
        [Required]
        //7[DataMember]
        public String PlotDescription { get; set; }
        //[DataMember]
        public virtual ICollection<Genre> Genres { get; set; }

    }
}
