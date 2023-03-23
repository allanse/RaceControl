using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;

namespace RaceControl.Dominio.Servicos
{
    public class ServicoPistaCorrida : ServicoBase<PistaCorrida>
    {
        public ServicoPistaCorrida(IRepositorioBase<PistaCorrida> repositorio) : base(repositorio)
        {
        }
    }
}
