using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    public class Student
    {
        public string firstName;
        public string fastName;
        public DateTime dateOfBirth;
        DateTime applicationTime;
        int Rating;
        public int personalCode;

        public Student(string firstName, string lastName, DateTime birthDate, int personalCode)
        {
            this.firstName = firstName;
            this.fastName = lastName;
            this.dateOfBirth = birthDate;
            this.personalCode = personalCode;
        }
    }
}
