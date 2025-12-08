using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.Models;

namespace Supermarket.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext (DbContextOptions<SupermarketContext> options)
            : base(options)
        {
        }

        public DbSet<Supermarket.Models.CategoryModel> CategoryModel { get; set; } = default!;
        public DbSet<Supermarket.Models.ProductModel> ProductModel { get; set; } = default!;
    }
}
