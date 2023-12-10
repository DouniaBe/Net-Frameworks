using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net_Frameworks.Models;

namespace Net_Frameworks.Data
{
    public class Net_FrameworksContext : DbContext
    {
        public Net_FrameworksContext (DbContextOptions<Net_FrameworksContext> options)
            : base(options)
        {
        }

        public DbSet<Net_Frameworks.Models.Product> Product { get; set; } = default!;

        public DbSet<Net_Frameworks.Models.Category> Category { get; set; } = default!;

        public DbSet<Net_Frameworks.Models.ProductCategory> ProductCategory { get; set; } = default!;
        public object Users { get; internal set; }
        public object Roles { get; internal set; }
    }
}
