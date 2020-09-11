using FluentValidation;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Validator.FluentValidator
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name Alani En Fazla 50 Karakter Olmalıdır");
            RuleFor(x => x.City).MaximumLength(50).EmailAddress().WithMessage("Luften Dogru Email Adresi Giriniz");
        }
    }
}
