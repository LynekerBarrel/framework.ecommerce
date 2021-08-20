using FluentValidation;
using System;

namespace framework.ecommerce.auth.domain.Dto.Usuario
{
    public class UsuarioDto
    {
        public Guid UsuarioLogadoId { get; set; }
        public Guid ClinicaId{ get; set; }

        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Celular { get;  set; }
        public string Crmv { get;  set; }
        public string Mapa { get;  set; }
        public string Cargo { get;  set; }
        public bool Contratante { get;  set; }

        //EF Relation
        public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
        {
            public UsuarioDtoValidator()
            {

                RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

                RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            }
        }
    }
}
