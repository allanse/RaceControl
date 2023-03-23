using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;
using System.Threading.Tasks;

namespace RaceControl.Dominio.Servicos
{
    public abstract class ServicoBase<TEntidade> : IServicoBase<TEntidade> where TEntidade : EntidadeBase
    {
        protected readonly IRepositorioBase<TEntidade> repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task Add(TEntidade obj)
        {
            await repositorio.Add(obj);
        }
        public async Task Update(TEntidade obj)
        {
            await repositorio.Update(obj);
        }
        public async Task Remove(int id)
        {
            await repositorio.Remove(id);
        }        

        public Task<TEntidade> GetById(int id)
        {
            return repositorio.GetById(id);
        }

    }
}
