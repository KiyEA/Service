using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UsingService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace UsingService.Context
{
    public class RouteContext : DbContext
    {
        public RouteContext(DbContextOptions<RouteContext> options) : base(options) { }
        public DbSet<Route> Routes { get; set; }

    }

}
