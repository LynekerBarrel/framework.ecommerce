using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using framework.ecommerce.api.auth.Models;
using framework.ecommerce.api.auth.Controllers.Base;
using framework.ecommerce.api.auth.domain.dto.usuario.request;
using framework.ecommerce.api.util.Config;
using framework.ecommerce.api.auth.domain.dto.usuario.response;
using framework.ecommerce.api.util.Data;

namespace framework.ecommerce.api.auth.Controllers
{
    /// <summary>
    /// AuthController
    /// </summary>
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        /// <summary>
        /// AuthController
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        public AuthController(IServiceProvider serviceProvider,
                              SignInManager<Usuario> signInManager,
                              UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Registrar
        /// </summary>
        /// <param name="usuarioRegistro"></param>
        /// <returns></returns>
        [HttpPost("nova-conta")]
        [Produces("application/json", Type = typeof(UsuarioLoginResponse))]
        public async Task<ActionResult> Registrar(UsuarioCadastroRequest usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new Usuario
            {
                Nome = usuarioRegistro.Nome,
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                PhoneNumber = usuarioRegistro.Telefone,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimsAsync(user, GetCliveClaim(user));

                return CustomResponse(await GerarJwt(user),//, usuarioRegistro.IdEmpresa), 
                    framework.ecommerce.api.auth.domain.Enum.StatusCodeApi.Created);
            }

            foreach (var error in result.Errors)
            {
                AddError(error.Description);
            }

            return CustomResponse<object>();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns></returns>
        [HttpPost("get-token")]
        [Produces("application/json", Type = typeof(UsuarioLoginRequest))]
        public async Task<ActionResult> Login(UsuarioLoginRequest usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Password, false, true);

            if (result.Succeeded)
            {
                _ = await _userManager.FindByEmailAsync(usuarioLogin.Email);

                return CustomResponse(await GerarJwt(null, usuarioLogin.Email));
            }

            if (result.IsLockedOut)
            {
                AddError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse<object>();
            }

            AddError("Usuário ou Senha incorretos");
            return CustomResponse<object>();
        }

        /// <summary>
        /// GetCliveClaim
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private List<Claim> GetCliveClaim(IdentityUser user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            claims.Add(new Claim(ClaimTypes.Role, auth.domain.Enum.Perfil.Administrador.ToString()));
            return claims;
        }

        /// <summary>
        /// GerarJwt
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        private async Task<UsuarioLoginResponse> GerarJwt(Usuario usuario = null, string email = null)
        {
            var user = await _userManager.FindByEmailAsync(email ?? usuario.Email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuario(claims, user);
            var encodedToken = CodificarToken(identityClaims);

            return ObterRespostaToken(encodedToken, user, claims);
        }

        private async Task<ClaimsIdentity> ObterClaimsUsuario(ICollection<Claim> claims, Usuario user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, auth.domain.Enum.Perfil.Administrador.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private string CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(EnvironmentConfig.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = EnvironmentConfig.Emissor,
                Audience = EnvironmentConfig.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(EnvironmentConfig.ExpiracaoHoras)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private UsuarioLoginResponse ObterRespostaToken(string encodedToken, Usuario user, IEnumerable<Claim> claims)
        {
            return new UsuarioLoginResponse(
                user.Id,
                user.UserName,
                encodedToken,
                TimeSpan.FromHours(Convert.ToInt32(EnvironmentConfig.ExpiracaoHoras)).TotalSeconds,
                claims.Select(c => new ClaimDto { Type = c.Type, Value = c.Value })
                );
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    }
}