using fluentValidationPractice;
using System.ComponentModel.DataAnnotations;

PersonModel person = new PersonModel()
{
    age = 19,
    FirstName = "giioo",
    DayOfBirth= new DateTime(2044,11,22)
};

personValidation validator=new personValidation();

var results = validator.Validate(person);

if(!results.IsValid)
{
    foreach(var failure in results.Errors)
    {
       // Console.WriteLine(failure.PropertyName+":"+failure);
        Console.WriteLine(failure);
    }
}
else Console.WriteLine("Well , I Recieved A Person");