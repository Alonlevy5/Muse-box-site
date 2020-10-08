using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Musebox_Web_Project.Models;

namespace Musebox_Web_Project.Data
{
    public class Musebox_Web_ProjectContext : DbContext
    {
        public Musebox_Web_ProjectContext (DbContextOptions<Musebox_Web_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Musebox_Web_Project.Models.Product> Products { get; set; }

        public DbSet<Musebox_Web_Project.Models.Brand> Brand { get; set; }

        public DbSet<Musebox_Web_Project.Models.User> Users { get; set; }

        public DbSet<Musebox_Web_Project.Models.Order> Order { get; set; }

    }
}
