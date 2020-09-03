using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi23_DemoReactAPI.Models
{
    public class MyDbContext:DbContext
    {
        public DbSet<Loai> Loais { get; set; }
        public MyDbContext(DbContextOptions opts): base(opts)
        {

        }
    }
}
