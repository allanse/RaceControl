using Microsoft.EntityFrameworkCore;
using RaceControl.Dominio.DTOs;
using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;
using RaceControl.Infraestrutura.Configuracao.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceControl.Infraestrutura.Data.Repositorios
{
    public class RepositorioCompetidor : RepositorioBase<Competidor>, IRepositorioCompetidor
    {       
        public RepositorioCompetidor(Contexto contexto) : base(contexto)
        {
            
        }

        public async Task<IEnumerable<CompetidorComTempoMedioDTO>> ObterCompetidoresComTempoMedioNasCorridas()
        {
            var list = await (from c in Db.Competidores.AsNoTracking()
                            join h in Db.HistoricoCorrida.AsNoTracking() on c.Id equals h.Competidor.Id
                            group h by new { c.Id, c.Nome} into g
                            select new CompetidorComTempoMedioDTO
                            {
                                Id = g.Key.Id,
                                Nome = g.Key.Nome,
                                TempoMedio = g.Average(x => x.TempoGasto)
                            }).ToListAsync();

            return list;
        }

        public async Task<IEnumerable<CompetidorSemCorridaDTO>> ObterCompetidoresSemCorrida()
        {
            var competidores = await GetAll();

            var historicoCorridaCompetidorIds = Db.HistoricoCorrida.Select(h => h.Competidor.Id).Distinct().ToList();

            var competidoresSemCorrida = competidores.Where(c => !historicoCorridaCompetidorIds.Contains(c.Id)).Select(c => new CompetidorSemCorridaDTO { Nome = c.Nome }).ToList();

            return competidoresSemCorrida;
        }
    }
}
