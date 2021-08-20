using System.Threading.Tasks;

namespace framework.ecommerce.auth.domain.Interface.Context
{
    public interface IContext
    {
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}
