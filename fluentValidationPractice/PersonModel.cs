using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fluentValidationPractice
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public int age { get; set; }
        public DateTime DayOfBirth { get; set; }
    }
}
