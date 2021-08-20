using System.Data;
using System.Threading.Tasks;

namespace framework.ecommerce.api.auth.domain.Interface.Context
{
    public interface IDataFactory
    {
        IDbConnection OpenConnection(string conn = null);
        Task<IDbConnection> OpenConnectionAsync(string conn = null);
    }
}
