using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace User_and_groups.Models
{
    public class AllDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Groups> Groups { get; set; }
    }

    
}