
using FluentValidation;
using System;

namespace framework.ecommerce.api.auth.domain.dto.usuario.request
{
    public class UsuarioCadastroRequest
    {
        public Guid IdentityId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefone { get; set; }

        public class UsuarioCadastroRequestValidator : AbstractValidator<UsuarioCadastroRequest>
        {
            public UsuarioCadastroRequestValidator()
            {

                RuleFor(c => c.Password)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            }
        }
    }
}
