using Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Eventos.IO.Domain.Interfaces
{
    //REPOSITÓRIO GENÉRICO = SERVE PARA QUALQUER ENTIDADE
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
        /*aqui estou dizendo que meu IRepository vai interpretar uma entidade genérica (TEntity), onde vai implementar
         * o IDisposable, onde a minha TEntity será a minha classe de Entity que fica lá no core*/
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
