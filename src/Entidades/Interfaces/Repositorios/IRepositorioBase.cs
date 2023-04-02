using RaceControl.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Interfaces
{
    public interface IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {        
        Task Add(TEntidade obj);
        Task Update(TEntidade obj);
        Task Remove(int id);
        Task<TEntidade> GetById(int id);
        Task<IEnumerable<TEntidade>> GetAll();
    }
}
