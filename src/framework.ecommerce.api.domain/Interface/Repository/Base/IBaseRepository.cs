using framework.ecommerce.api.auth.domain.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace framework.ecommerce.api.auth.domain.Interface.Repository.Base
{
    public interface IBaseRepository<T>
    {
        Task<T> Add(T entidade);
        Task<T> Update(T entidade);
        Task<T> Delete(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<(IEnumerable<T> items, int qtd)> Get(Expression<Func<T, bool>> filtro = null,
            PaginacaoEntradaDto paginacao = null,
            params Expression<Func<T, object>>[] includes);
    }
}
