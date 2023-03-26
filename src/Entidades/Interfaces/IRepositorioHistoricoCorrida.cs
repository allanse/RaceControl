using RaceControl.Dominio.DTOs;
using RaceControl.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Interfaces
{
    public interface IRepositorioHistoricoCorrida : IRepositorioBase<HistoricoCorrida>
    {
        Task<IEnumerable<PistaCorrida>> ObterPistasUtilizadas();        
    }
}
