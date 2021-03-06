using System;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Commands.AddPerson
{
    public class AddRelatedPersonValidator : AbstractValidator<AddPersonCommand>
    {
        public AddRelatedPersonValidator()
        {
            RuleFor(o => o.PersonalNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().NotNull().Length(11, 11).WithMessage("Model.Invalid.PersonalNumber").Matches("^[0-9]*$").WithMessage("Model.Invalid.PersonalNumber");

            RuleFor(o => o.FirstName)
                .NotEmpty().NotNull().Length(2, 50).Must(StringAlphabetValidation).WithMessage("Model.Invalid.FirstName");

            RuleFor(o => o.LastName)
                .NotEmpty().Length(2, 50).Must(StringAlphabetValidation).WithMessage("Model.Invalid.LastName");

            RuleFor(o => o.PhoneNumber)
                .Length(4, 50).Matches("^[0-9]*$").WithMessage("Model.Invalid.PhoneNumber");

            RuleFor(o => o.Birthday)
                .Must(BeValidAge).WithMessage("Model.Invalid.Age");

            RuleFor(o => o.CityId)
                .GreaterThan(0).WithMessage("Model.Invalid.CityId");
        }

        protected bool BeValidAge(DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            return age > 18;
        }

        protected bool StringAlphabetValidation(string firstName)
        {
            if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
            {
                return true;
            }

            foreach (var @char in firstName)
            {
                var intValueOfChar = (int)@char;

                //ეს რიცხვები ქართული ალფავიტის პირველი და ბოლო ასოების ასკის შესატყვისი ასოები არის
                if (intValueOfChar < 4304 || intValueOfChar > 4336)
                {
                    return false;
                }
            }

            return true;
        }
    }
}