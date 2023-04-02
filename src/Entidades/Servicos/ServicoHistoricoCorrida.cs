using RaceControl.Dominio.DTOs;
using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Servicos
{
    public class ServicoHistoricoCorrida : ServicoBase<HistoricoCorrida>
    {
        private readonly IRepositorioPistaCorrida repositorioHistoricoCorrida;

        public ServicoHistoricoCorrida(IRepositorioBase<HistoricoCorrida> repositorio, IRepositorioPistaCorrida repositorioHistoricoCorrida) : base(repositorio)
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
    }
}
