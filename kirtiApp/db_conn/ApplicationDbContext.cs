using kirtiApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace kirtiApp.db_conn
{
    public class ApplicationDbContext : IdentityDbContext
    {

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
            public DbSet<Employee> employees { get; set; }
            public DbSet<Address> Cites { get; set; }
      

         
        }
    }


