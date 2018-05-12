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
        void Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
