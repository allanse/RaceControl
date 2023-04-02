using RaceControl.Dominio.DTOs;
using RaceControl.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Interfaces
{
    public interface IRepositorioCompetidor : IRepositorioBase<Competidor>
    {
        Task<IEnumerable<CompetidorSemCorridaDTO>> ObterCompetidoresSemCorrida();

        Task<IEnumerable<CompetidorComTempoMedioDTO>> ObterCompetidoresComTempoMedioNasCorridas();
    }
}
