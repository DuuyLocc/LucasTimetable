using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.ViewModel.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Ho).NotEmpty().WithMessage("please input first name")
                .MaximumLength(50).WithMessage("Ho is less than 50 words");

            RuleFor(x => x.Ten).NotEmpty().WithMessage("please input name")
                .MaximumLength(50).WithMessage("Ho is less than 50 words");

            RuleFor(x => x.NgaySinh).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("age less than 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("please input Email")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email is invalid ");

            RuleFor(x => x.SoDienThoai).NotEmpty().WithMessage("please input phone number");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("please input Username");

            RuleFor(x => x.Password).NotEmpty().WithMessage("please input Password")
                .MinimumLength(6).WithMessage("Password is more than 6 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Password is not match");
                }
            });
        }
    }
}
