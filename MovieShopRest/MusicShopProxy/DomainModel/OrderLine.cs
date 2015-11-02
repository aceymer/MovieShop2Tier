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
    [Table("OrderLine")]
    class OrderLine
    {
        [Key]
        public int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public int amount { get; set; }


    }
}
