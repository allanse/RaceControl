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
    public class RepositorioHistoricoCorrida : RepositorioBase<HistoricoCorrida>, IRepositorioHistoricoCorrida
    {
        private readonly IRepositorioBase<Competidor> repositorioCompetidor;

        public RepositorioHistoricoCorrida(Contexto contexto, IRepositorioBase<Competidor> repositorioCompetidor) : base(contexto)
        {
            this.repositorioCompetidor = repositorioCompetidor;
        }

        public async Task<IEnumerable<PistaCorrida>> ObterPistasUtilizadas()
        {            
            return await Db.HistoricoCorrida
                .AsNoTracking()
                .Include(p => p.PistaCorrida)
                .Distinct()
                .OrderBy(p => p.PistaCorrida.Descricao)
                .Select(p => new PistaCorrida { Descricao = p.PistaCorrida.Descricao })
                .ToListAsync();
        }

        public async Task<IEnumerable<CompetidorSemCorridaDTO>> ObterCompetidoresSemCorrida()
        {
            var competidores = await repositorioCompetidor.GetAll();

            var historicoCorridaCompetidorIds = Db.HistoricoCorrida.Select(h => h.Competidor.Id).Distinct().ToList();

            var competidoresSemCorrida = competidores.Where(c => !historicoCorridaCompetidorIds.Contains(c.Id)).Select(c => new CompetidorSemCorridaDTO { Nome = c.Nome }).ToList();
            
            return competidoresSemCorrida;
        }
    }
}
