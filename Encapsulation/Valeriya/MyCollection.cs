using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Encapsulation.Valeriya
{
    class MyCollection<T>: Collection<T>
    {
        protected override void ClearItems()
        {
            base.ClearItems();
            Console.WriteLine("Cleared");
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Console.WriteLine("Item removed");
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            Console.WriteLine("Item inserted");
        }

        protected override void SetItem(int index, T item)
        {
            base.SetItem(index, item);
            Console.WriteLine("Item replaced");
        }
    }
}
