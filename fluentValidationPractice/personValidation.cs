using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fluentValidationPractice
{
    public class personValidation:AbstractValidator<PersonModel>
    {
        public personValidation()
        {
            RuleFor(p => p.age)
                .NotEmpty()
                .LessThan(20).WithMessage("Please Enter {PropertyName} Less Than 20");

            RuleFor(p => p.FirstName)
                .Cascade(cascadeMode: CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(3, 20).WithMessage("Please Enter {PropertyName}e  with 3-20 symbols ")
                .Must(IsValidName).WithMessage("{PropertyName}Contaions Invalid Characters");
            RuleFor(p => p.DayOfBirth)
                .Cascade(cascadeMode: CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(IsValidAge).WithMessage("{PropertyName} Is Not Valid");


        }
        protected bool IsValidName(string name)
        {
            name = name.Replace("-", "");
            name = name.Replace(" ", "");
            return name.All(Char.IsLetter);
        }
        protected bool IsValidAge(DateTime date)
        {
            int currentDate=DateTime.Now.Year;
            int bodYear=date.Year;
            if(currentDate>bodYear&& currentDate-bodYear<120) 
            {
                return true;
            }
            return false;
        }
    }
}
