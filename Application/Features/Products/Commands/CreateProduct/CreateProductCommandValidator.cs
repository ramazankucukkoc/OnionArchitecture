using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim Alanı Boş geiliemez")
                .Length(2,30).WithMessage("Name alanı 2 ile 30 arasında kelime almalıdır");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama Alanı Boş geiliemez")
              .Length(2, 50).WithMessage("Açıklama alanı 2 ile 50 arasında kelime almalıdır");

          
        }
    }
}
