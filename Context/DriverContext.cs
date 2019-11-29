using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UsingService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace UsingService.Context
{
    public class DriverContext : DbContext
    {
        public DriverContext(DbContextOptions<DriverContext> options) : base(options) { }
        public DbSet<Driver> Drivers { get; set; }

    }

}
