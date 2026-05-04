using ControleAtendimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAtendimentos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AtendimentoModel> Atendimentos { get; set; }
        public DbSet<SetorModel> Setores{ get; set; }
        public DbSet<PrioridadeModel> Prioridades{ get; set; }
        public DbSet<ChamadoModel> Chamados{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChamadoModel>()
                .HasOne(c => c.setor)
                .WithMany(s => s.chamados)
                .HasForeignKey(c => c.setorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChamadoModel>()
                .HasOne(c => c.prioridade)
                .WithMany(p => p.chamados)
                .HasForeignKey(c => c.prioridadeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
