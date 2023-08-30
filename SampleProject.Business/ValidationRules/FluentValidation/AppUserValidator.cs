using FluentValidation;
using SampleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Business.ValidationRules.FluentValidation
{
    public class AppUserValidator : AbstractValidator<AppUser>
    {
    }
}
