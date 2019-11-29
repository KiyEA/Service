using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UsingService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace UsingService.Context
{
    public class BusContext : DbContext
    {
        public BusContext(DbContextOptions<BusContext> options) : base(options) { }
        public DbSet<Bus> Buses { get; set; }

    }

}
