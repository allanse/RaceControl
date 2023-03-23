using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Servicos
{
    public class ServicoHistoricoCorrida : ServicoBase<HistoricoCorrida>
    {
        private readonly IRepositorioHistoricoCorrida repositorioHistoricoCorrida;

        public ServicoHistoricoCorrida(IRepositorioBase<HistoricoCorrida> repositorio, IRepositorioHistoricoCorrida repositorioHistoricoCorrida) : base(repositorio)
        {
            this.repositorioHistoricoCorrida = repositorioHistoricoCorrida;
        }

        public bool ValidarDataCorrida(HistoricoCorrida historicoCorrida)
        {
            if  (historicoCorrida.DataCorrida > DateTime.Now)
            {
                return false;
            }

            return true;
        }
        public async Task<IEnumerable<PistaCorrida>> ObterPistasUtilizadas()
        {
            var pistas = await repositorioHistoricoCorrida.ObterPistasUtilizadas();

            return pistas;
        }
    }
}
