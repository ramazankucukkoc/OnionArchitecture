using FluentValidation;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim Alanı Boş geçilemez")
                .Length(2, 30).WithMessage("Name alanı 2 ile 30 arasında kelime almalıdır");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama Alanı Boş geçilemez")
              .Length(2, 50).WithMessage("Açıklama alanı 2 ile 50 arasında kelime almalıdır");


        }
    }
}
