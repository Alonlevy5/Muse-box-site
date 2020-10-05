using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musebox_Web_Project.Models
{
    public class Products
    {

        [Required]
        [DataType(DataType.Text)]
        [Key]
        public int ProductID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string ProductType { get; set; }
        [Required]
        
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
       
        
        //public virtual ICollection<Sales> Sales { get; set; }


    }
}
