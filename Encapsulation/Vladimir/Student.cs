using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Vladimir
{
    public class Student
    {
        public string firstName;
        public string secondName;
        public int personalCode;
        public DateTime birthDate;
        public int rating;

        
        public Student (string firstName, string lastName, int personalCode, DateTime birthDate, int rating)
        {
            this.firstName = firstName;
            this.secondName = lastName;
            this.personalCode = personalCode;
            this.birthDate = birthDate;
            this.rating = rating;

        }

    }
}
