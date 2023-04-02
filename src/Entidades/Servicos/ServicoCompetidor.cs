using RaceControl.Dominio.DTOs;
using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Servicos
{
    public class ServicoCompetidor : ServicoBase<Competidor>
    {
        private readonly IRepositorioCompetidor repositorioCompetidor;

        public ServicoCompetidor(IRepositorioBase<Competidor> repositorio, IRepositorioCompetidor repositorioCompetidor) : base(repositorio)
        {
            this.repositorioCompetidor = repositorioCompetidor;
        }

        public async Task<IEnumerable<CompetidorSemCorridaDTO>> ObterCompetidoresSemCorrida()
        {
            var compeditoresSemCorrida = await repositorioCompetidor.ObterCompetidoresSemCorrida();

            return compeditoresSemCorrida;
        }

        public async Task<IEnumerable<CompetidorComTempoMedioDTO>> ObterCompetidoresComTempoMedioNasCorridas()
        {
            var compeditoresSemCorrida = await repositorioCompetidor.ObterCompetidoresComTempoMedioNasCorridas();

            return compeditoresSemCorrida;
        }
    }
}
