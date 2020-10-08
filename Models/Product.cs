using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musebox_Web_Project.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string ProductType { get; set; }

        [Required]
        [Display(Name = "Brand Name")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
       
        //public virtual ICollection<Sales> Sales { get; set; }


    }
}
