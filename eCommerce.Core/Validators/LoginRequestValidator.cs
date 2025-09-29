using eCommerce.Core.Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() {
            RuleFor(temp => temp.Email).NotEmpty().WithMessage("Emial is Required").EmailAddress().WithMessage("Invalid Email Address format");
            RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is Required");
        }
    }
}
