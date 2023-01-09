using FluentValidation;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.UserForRegisterDto.Email)
                .EmailAddress().WithMessage("Email formatı uygun olamlıdır. ")
                .NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
            RuleFor(r => r.UserForRegisterDto.Password)
                .NotEmpty().WithMessage("Pasword alanı boş geçilmemelidir.");

        }
    }
}
