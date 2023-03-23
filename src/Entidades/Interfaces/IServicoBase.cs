using RaceControl.Dominio.Entidades;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Interfaces
{
    public interface IServicoBase<TEntidade> where TEntidade : EntidadeBase
    {
        Task Add(TEntidade obj);
        Task Update(TEntidade obj);
        Task Remove(int id);
        Task<TEntidade> GetById(int id);
    }
}
