using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int PersonalCode { get; private set; }
        public Student(string firstName, string lastName, int personalCode, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalCode = personalCode;
            BirthDate = birthDate;
        }
        public override string ToString()
        {
            return String.Format(FirstName, LastName, BirthDate, PersonalCode);
        }
    }
}
