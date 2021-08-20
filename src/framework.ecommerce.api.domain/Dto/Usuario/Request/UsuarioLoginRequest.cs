
using FluentValidation;

namespace framework.ecommerce.api.auth.domain.dto.usuario.request
{
    public class UsuarioLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class UsuarioLoginRequestValidator : AbstractValidator<UsuarioLoginRequest>
        {
            public UsuarioLoginRequestValidator()
            {
                RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

                RuleFor(c => c.Password)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            }
        }
    }
}
