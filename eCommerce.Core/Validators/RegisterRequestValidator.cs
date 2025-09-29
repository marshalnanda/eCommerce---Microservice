using eCommerce.Core.Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(temp => temp.Email).NotEmpty().WithMessage("Emial is Required").EmailAddress().WithMessage("Invalid Email Address format");
            RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is Required");
            RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("PersonName is Required").Length(1, 50).WithMessage("PersonName limit should be between 1-50 Characters only");
            RuleFor(temp => temp.Gender).NotEmpty().WithMessage("Gender is Required").IsInEnum().WithMessage("Invalid Gender");
        }
    }
}
