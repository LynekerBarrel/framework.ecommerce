using System;
using System.Threading.Tasks;


namespace framework.ecommerce.auth.domain.Interface.Service
{
    public interface ILogService
    {
        Task LogRequest(string method, string scheme, string host, string path,
             string queryString, string bodyContent);

        Task LogResponse(string method, string scheme, string host, string path,
            string queryString, string elapsedMilliseconds, int statusCode, string bodyContent = null
            );

        Task LogInfo(string message);

        Task LogError(Exception exception);
    }
}
