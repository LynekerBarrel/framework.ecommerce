namespace framework.ecommerce.api.auth.domain.Dto.Helper
{
    public class AppSettings
    {
        public string WebApiUrl { get; set; }
        public string SecretId { get; set; }
        public string ClientId { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
