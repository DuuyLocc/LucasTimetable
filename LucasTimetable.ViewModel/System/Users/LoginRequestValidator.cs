using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.ViewModel.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Miss username");

            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Miss password");
        }
    }
}
