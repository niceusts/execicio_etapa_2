using execicio.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace execicio.Data
{
    public class ExecicioContext : DbContext
    {
        public ExecicioContext(DbContextOptions<ExecicioContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Aluno> aluno { get; set; }

    }
}
