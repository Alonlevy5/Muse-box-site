using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Price")]
        public int ProductPrice { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string ProductType { get; set; }

        public byte[] Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required]
        [Display(Name = "Brand Name")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

    }
}
