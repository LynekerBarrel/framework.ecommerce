using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace framework.ecommerce.api.util.Config
{
    /// <summary>
    /// CustomAuthorization
    /// </summary>
    public class CustomAuthorization
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c =>
                        (c.Type == ClaimTypes.Role && c.Value == "Administrador") ||
                        (c.Type == ClaimTypes.Role && c.Value == "Gestor") ||
                        (c.Type == claimName && c.Value.Contains(claimValue)));
        }

    }

    /// <summary>
    /// ClaimsAuthorizeAttribute
    /// </summary>
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }

    /// <summary>
    /// RequisitoClaimFilter
    /// </summary>
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        /// <summary>
        /// RequisitoClaimFilter
        /// </summary>
        /// <param name="claim"></param>
        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        /// <summary>
        /// OnAuthorization
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}