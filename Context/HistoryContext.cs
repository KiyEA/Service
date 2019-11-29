using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UsingService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace UsingService.Context
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options) { }
        public DbSet<History> Histories { get; set; }

    }

}
