using Futebol.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futebol.Dados
{
    public class FutebolContext: DbContext
    {
        public FutebolContext(DbContextOptions<FutebolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>().HasKey(ac => ac.timeId);
            modelBuilder.Entity<Time>().HasKey(ac => ac.competicaoId);
            modelBuilder.Entity<Competicao>().HasKey(ac => new { ac.timeId, ac.jogoId });
            modelBuilder.Entity<Jogo>().HasKey(ac => ac.arbitragemId);
            modelBuilder.Entity<Arbitragem>().HasKey(ac => ac.jogoId);
        }
     
        public DbSet<Jogador> Jogadores { get; set; }
     
        public DbSet<Futebol.Models.Time> Time { get; set; }
     
        public DbSet<Futebol.Models.Competicao> Competicao { get; set; }
     
        public DbSet<Futebol.Models.Jogo> Jogo { get; set; }
     
        public DbSet<Futebol.Models.Arbitragem> Arbitragem { get; set; }

    }
}
