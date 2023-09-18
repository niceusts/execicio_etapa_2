using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using execicio.Models;

namespace execicio.Data
{
    public class execicioContext : DbContext
    {
        public execicioContext (DbContextOptions<execicioContext> options)
            : base(options)
        {
        }

        public DbSet<execicio.Models.Categoria> Categoria { get; set; } = default!;
    }
}
