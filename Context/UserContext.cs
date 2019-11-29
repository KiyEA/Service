using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UsingService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace UsingService.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

    }
   
}
