
using framework.ecommerce.auth.domain.Interface.Repository;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace framework.ecommerce.auth.domain.dto.usuario.request
{
    public class UsuarioOnboardingRequest
    {
        public Guid IdentityId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public class UsuarioOnboardingRequestValidator : AbstractValidator<UsuarioOnboardingRequest>
        {
            private readonly IUsuarioRepository _usuarioRepository;

            public UsuarioOnboardingRequestValidator(IUsuarioRepository usuarioRepository)
            {
                _usuarioRepository = usuarioRepository;

                RuleFor(c => c.IdentityId)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

                RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

                RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

                RuleFor(x => x.Email).MustAsync(UsuarioNaoExiste)
                    .WithMessage("Usuário já está cadastrado");
            }

            private async Task<bool> UsuarioNaoExiste(string email, CancellationToken arg2)
            {
                //var res = (await _usuarioRepository.Get(x => x.Email == email));
                var usuarioExiste = (await _usuarioRepository.Get(x => x.Email == email)).qtd > 0;
                //var teste = (await _usuarioRepository.Get(x => x.Nome == "Nycolas"));
                return !usuarioExiste;
            }

        }
    }
}
