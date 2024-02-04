using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rdzienisz.Models;

namespace rdzienisz.Data
{
    public class rdzieniszContext : IdentityDbContext
    {
        public rdzieniszContext (DbContextOptions<rdzieniszContext> options)
            : base(options)
        {
        }

        public DbSet<rdzienisz.Models.Movie> Movie { get; set; } = default!;
    }
}
