using Microsoft.EntityFrameworkCore;
using RaceControl.Dominio.Entidades;

namespace RaceControl.Infraestrutura.Configuracao.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}

        public DbSet<Competidor> Competidores { get; set; }
        public DbSet<PistaCorrida> PistaCorrida { get; set; }
        public DbSet<HistoricoCorrida> HistoricoCorrida { get; set; }       
    }
}