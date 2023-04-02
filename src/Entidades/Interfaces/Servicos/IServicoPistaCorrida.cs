using RaceControl.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Interfaces.Servicos
{
    public interface IServicoPistaCorrida
    {
        Task<IEnumerable<PistaCorrida>> ObterPistasUtilizadas();
    }
}
