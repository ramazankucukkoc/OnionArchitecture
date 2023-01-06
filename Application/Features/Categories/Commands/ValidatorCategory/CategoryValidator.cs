using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.ValidatorCategory
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Lütfen Category Adı Alanını Geçmeyiniz.")
                .MaximumLength(50).MinimumLength(2).WithMessage("Lütfen Kategori adını 5 ile 50 karakter arasında giriniz.");

            RuleFor(c => c.Description).NotEmpty().NotNull().WithMessage("Lütfen Kategori Açıklama Alanını Geçmeyiniz.")
               .MaximumLength(50).MinimumLength(2).WithMessage("Lütfen Kategori adını 5 ile 50 karakter arasında giriniz.");


        }
    }
}
