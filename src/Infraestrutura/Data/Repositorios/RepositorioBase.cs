using Microsoft.EntityFrameworkCore;
using RaceControl.Dominio.Entidades;
using RaceControl.Dominio.Interfaces;
using RaceControl.Infraestrutura.Configuracao.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceControl.Infraestrutura.Data.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : EntidadeBase, new()
    {
        protected readonly Contexto Db;
        protected readonly DbSet<TEntidade> DbSet;
        public RepositorioBase(Contexto contexto)
        {
            Db = contexto;
            DbSet = Db.Set<TEntidade>();
        }
        public async Task Add(TEntidade obj)
        {
            await DbSet.AddAsync(obj);
            await Db.SaveChangesAsync();
        }
        public async Task Update(TEntidade obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            Db.Entry(new TEntidade { Id = id }).State = EntityState.Deleted;
            await Db.SaveChangesAsync();
        }

        public async Task<TEntidade> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntidade>> GetAll()
        {
            return await DbSet.ToListAsync();
        }




    }
}
