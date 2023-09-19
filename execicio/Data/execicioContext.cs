using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using execicio.Models;

namespace execicio.Data
{
    public class ExecicioContext : DbContext
    {
        public ExecicioContext (DbContextOptions<ExecicioContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Aluno> aluno { get; set; }

    }
}
