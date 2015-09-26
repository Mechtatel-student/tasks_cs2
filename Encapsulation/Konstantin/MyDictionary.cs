using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Encapsulation.Konstantin
{
    public struct Student
    {
        public string firstName, lastName;
        public DateTime birthDate;
        public int rating, personalCode;
    }
    class MyDictionary : KeyedCollection<Tuple<string,string,DateTime>,Student>
    {
        protected override Tuple<string, string, DateTime> GetKeyForItem(Student item)
        {
            return new Tuple<string, string, DateTime>(item.firstName, item.lastName, item.birthDate);
        }
    }
    class MyCollection : Collection<Student>
    {
        protected override void ClearItems()
        {
            base.ClearItems();
            Console.WriteLine("Collection is cleared");
        }
        protected override void InsertItem(int index, Student item)
        {
            base.InsertItem(index, item);
            Console.WriteLine("Item is inserted");
        }
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Console.WriteLine("Item is removed");
        }
        protected override void SetItem(int index, Student item)
        {
            base.SetItem(index, item);
            Console.WriteLine("Item is set");
        }        
    }
}
