using System.Collections.Generic;

namespace framework.ecommerce.api.auth.domain.dto.usuario.response
{
    public class UsuarioLoginResponse
    {
        public string IdentityId { get; private set; }
        public string Login { get; private set; }
        public string Token { get; private set; }
        public double ExpiresIn { get; private set; }
        public IEnumerable<ClaimDto> Claims { get; set; }

        public UsuarioLoginResponse()
        {

        }

        public UsuarioLoginResponse(string identityId, string login, string token, double expiresIn, IEnumerable<ClaimDto> claims)
        {
            IdentityId = identityId;
            Login = login;
            Token = token;
            ExpiresIn = expiresIn;
            Claims = claims;
        }
    }

    public class ClaimDto
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
