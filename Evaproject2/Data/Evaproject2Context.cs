using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Evaproject2.Models
{
    public class Evaproject2Context : DbContext
    {
        public Evaproject2Context (DbContextOptions<Evaproject2Context> options)
            : base(options)
        {
        }

        public DbSet<Evaproject2.Models.Aspecto> Aspecto { get; set; }
    }
}
