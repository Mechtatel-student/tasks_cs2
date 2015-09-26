using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    public class MyCollection: Collection<Student>
    {
        protected override void ClearItems()
        {
            base.ClearItems();
            Console.WriteLine("MyCollection was cleared {0}", DateTime.Now);
        }
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Console.WriteLine("1 item was removed from MyCollection at {0}", DateTime.Now);
        }
        protected override void SetItem(int index, Student item)
        {
            base.SetItem(index, item);
            Console.WriteLine("1 item was replaced in MyCollection at {0}", DateTime.Now);

        }
        protected override void InsertItem(int index, Student item)
        {
            base.InsertItem(index, item);
            Console.WriteLine("1 item was inserted in MyCollection at {1} index, {0}", DateTime.Now, index);
        }

    }
}
