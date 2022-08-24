using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Bugünün tarihinden önce bir tarihe araç kiralayamazsınız.");
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate).WithMessage("Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.");


        }
    }
}
