using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Encapsulation.Valeriya
{
    class MyDictionary: KeyedCollection<Tuple<string, string, DateTime, int>, Student>
    {
        protected override Tuple<string, string, DateTime, int> GetKeyForItem(Student item)
        {
            return Tuple.Create(item.firstName, item.fastName, item.dateOfBirth, item.personalCode);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            Console.WriteLine("Cleared");
        }

        protected override void InsertItem(int index, Student item)
        {
            base.InsertItem(index, item);
            Console.WriteLine("Item inserted");
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Console.WriteLine("Item removed");
        }

        protected override void SetItem(int index, Student item)
        {
            base.SetItem(index, item);
            Console.WriteLine("Item replaced");
        }
    }
}
