using System.Threading.Tasks;

namespace framework.ecommerce.api.auth.domain.Interface.Context
{
    public interface IContext
    {
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}
