using response = framework.ecommerce.auth.domain.dto.usuario.response;
using request = framework.ecommerce.auth.domain.dto.usuario.request;
using System.Threading.Tasks;
using framework.ecommerce.auth.domain.Dto.Cliente.Response;
using framework.ecommerce.auth.domain.dto.usuario.request;

namespace framework.ecommerce.auth.domain.Interface.Service
{
    public interface IUsuarioService
    {
        Task<BasicResponse> Onboarding(UsuarioOnboardingRequest dto);
    }
}
