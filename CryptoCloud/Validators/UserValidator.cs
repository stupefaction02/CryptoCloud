using CryptoCloud.Models;
using CryptoCloud.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            //RuleFor(customer => customer.Email)
            //    .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            //    .MaximumLength(100)
            //    .NotNull();

            //RuleFor(customer => customer.Password)
            //    .MinimumLength(8)
            //    .MaximumLength(50)
            //    .NotNull();
        }
    }
}
