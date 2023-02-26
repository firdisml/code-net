using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_net.Models;
using Microsoft.EntityFrameworkCore;

namespace code_net.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Character> Characters => Set<Character>();

    }
}