using FluentValidation;
using System;

namespace framework.ecommerce.api.auth.domain.Dto.Tag
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public class TagDtoValidator : AbstractValidator<TagDto>
        {
            public TagDtoValidator()
            {

                RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            }
        }
    }
}
