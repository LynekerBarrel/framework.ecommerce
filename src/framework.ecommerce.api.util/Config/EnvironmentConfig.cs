using System;

namespace framework.ecommerce.api.util.Config
{
    public static class EnvironmentConfig
    {
        public static string ConnectionStrings => Environment.GetEnvironmentVariable("ConnectionStrings");
        public static string Secret => Environment.GetEnvironmentVariable("Secret");
        public static string ClientId => Environment.GetEnvironmentVariable("ClientId");
        public static string SecretId => Environment.GetEnvironmentVariable("SecretId");
        public static string Emissor => Environment.GetEnvironmentVariable("Emissor");
        public static string ValidoEm => Environment.GetEnvironmentVariable("ValidoEm");
        public static string ExpiracaoHoras => Environment.GetEnvironmentVariable("ExpiracaoHoras");
    }
}
