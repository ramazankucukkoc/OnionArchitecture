using FluentValidation;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UserForLoginDto.Email)
                .NotEmpty().WithMessage("Email Alanı Boş Geçilemez")
                .EmailAddress().WithMessage("Email formatı uygun olamlıdır.");
            RuleFor(x => x.UserForLoginDto.Password)
                .NotEmpty().WithMessage("Password Alanı Boş Geçilemez");

        }
    }
}
