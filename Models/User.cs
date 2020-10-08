﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musebox_Web_Project.Models
{
    public class User
    {
        [Key]
        [Required]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "IsManager")]
        public bool IsManager { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}
