using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).InclusiveBetween(1900, DateTime.Now.Year);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0).WithMessage("Fiyat birimi 0 altında olamaz.");
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(10).WithMessage("Açıklama 10 karakterden uzun olmalı.");
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
        }

    }
}
