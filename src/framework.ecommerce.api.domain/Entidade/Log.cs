using framework.ecommerce.auth.domain.Enum;
using framework.ecommerce.util;
using System;

namespace framework.ecommerce.auth.domain.Entidade
{
    public class Log
    {
        public Log()
        {
            DataCriacao = DateTime.Now;
        }

        public TipoLog TipoLog { get; set; }
        public long Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public int? StatusCode { get; private set; }
        public string Message { get; private set; }
        public string CorrelationId { get; private set; }
        public string ElapsedMilliseconds { get; private set; }
        public string Exception { get; private set; }
        public string Scheme { get; private set; }
        public string Host { get; private set; }
        public string Path { get; private set; }
        public string QueryString { get; private set; }
        public string BodyContent { get; private set; }
        public string Method { get; private set; }

        public void LogRequest(string method, string correlationId, string scheme, string host, string path,
             string queryString, string bodyContent)
        {
            Message = "Request";
            Scheme = scheme;
            Host = host;
            Path = path;
            CorrelationId = correlationId;
            QueryString = queryString;
            BodyContent = bodyContent;
            TipoLog = TipoLog.Request;
            Method = method;
        }

        public void LogResponse(string method, string correlationId, string scheme, string host, string path,
            string queryString, string elapsedMilliseconds, int statusCode, string bodyContent = null
            )
        {
            Message = "Response";
            Scheme = scheme;
            Host = host;
            Path = path;
            CorrelationId = correlationId;
            QueryString = queryString;
            BodyContent = bodyContent;
            ElapsedMilliseconds = elapsedMilliseconds.ToString();
            StatusCode = statusCode;
            TipoLog = TipoLog.Response;
            Method = method;
        }

        public void LogInfo(string correlationId, string message)
        {
            Message = message;
            CorrelationId = correlationId;
            TipoLog = TipoLog.Info;
        }

        public void LogError(string correlationId, Exception exception)
        {
            Message = "Exception";
            CorrelationId = correlationId;
            Exception = Util.SerializarObjectParaJson(exception);
            TipoLog = TipoLog.Error;
        }
    }
}
