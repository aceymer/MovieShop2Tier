using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.DomainModel
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [EmailAddress]
        [Required]
        public String Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The password must be at least 6 characters long")]
        public String Password { get; set; }


    }
}
