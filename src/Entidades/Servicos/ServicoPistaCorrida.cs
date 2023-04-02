using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;
using RaceControl.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Servicos
{
    public class ServicoPistaCorrida : ServicoBase<PistaCorrida>, IServicoPistaCorrida
    {
        private readonly IRepositorioPistaCorrida repositorioPistaCorrida;

        public ServicoPistaCorrida(IRepositorioBase<PistaCorrida> repositorio, IRepositorioPistaCorrida repositorioPistaCorrida) : base(repositorio)
        {
            this.repositorioPistaCorrida = repositorioPistaCorrida;
        }

        public async Task<IEnumerable<PistaCorrida>> ObterPistasUtilizadas()
        {
            var pistas = await repositorioPistaCorrida.ObterPistasUtilizadas();

            return pistas;
        }
    }
}
