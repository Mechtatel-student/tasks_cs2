using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Encapsulation.Vladimir
{
    class MyCollection<T> : Collection<T>
    {
        protected override void ClearItems()
        {
            base.ClearItems();
            Console.WriteLine("Cleared");
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Console.WriteLine("Removed");
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            Console.WriteLine("Inserted");
        }

        protected override void SetItem(int index, T item)
        {
            base.SetItem(index, item);
            Console.WriteLine("Replaced");
        }
    }
}
