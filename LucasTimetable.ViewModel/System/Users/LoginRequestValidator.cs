using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.ViewModel.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        // declare constructor
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");

            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Password  is required");
        }
    }
}
