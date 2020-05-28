using Loss.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Loss.DataAccess
{
    public class LossContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public LossContext() : base("LocalConnection")
        { }
    }
}