using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Elena
{
    struct Student
    {
        public string FirstName;
        public string LastName;
        public DateTime ApplicationDate;
        public DateTime BirthDay;
        public int Rating;
        public int personalCode;

    }

    class MyCollection:Collection<Student>
    {
        protected override void ClearItems()
        {
            base.ClearItems();
            Console.WriteLine("Data on struct is cleaning!");
        }

        protected override void InsertItem(int index, Student item)
        {
            base.InsertItem(index, item);
            Console.WriteLine("New item inserted");

        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Console.WriteLine("Item {0} is removed", index);
        }

        protected override void SetItem(int index, Student item)
        {
            base.SetItem(index, item);
            Console.WriteLine("Item is seting");
        }
    }
}
