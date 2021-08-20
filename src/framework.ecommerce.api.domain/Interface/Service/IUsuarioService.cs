using response = framework.ecommerce.api.auth.domain.dto.usuario.response;
using request = framework.ecommerce.api.auth.domain.dto.usuario.request;
using System.Threading.Tasks;
using framework.ecommerce.api.auth.domain.Dto.Cliente.Response;
using framework.ecommerce.api.auth.domain.dto.usuario.request;

namespace framework.ecommerce.api.auth.domain.Interface.Service
{
    public interface IUsuarioService
    {
        Task<BasicResponse> Onboarding(UsuarioOnboardingRequest dto);
    }
}
