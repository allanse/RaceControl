using Dominio.Enums;
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

        public bool ValidarCompetidor(Competidor competidor)
        {
            if (competidor.Peso <=0)
            {
                return false;
            }

            if (competidor.Altura <= 0)
            {
                return false;
            }

            if (competidor.Sexo != ESexo.M)
            {
                return false;
            }

            if (competidor.Sexo != ESexo.F)
            {
                return false;
            }

            if (competidor.Sexo != ESexo.O)
            {
                return false;
            }

            return true;
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
