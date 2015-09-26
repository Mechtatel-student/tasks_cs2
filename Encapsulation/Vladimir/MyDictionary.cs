using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Encapsulation.Vladimir
{
    public class MyDictionary : KeyedCollection<Tuple<string, string, int, DateTime>, Student>
    {
        protected override Tuple<string, string, int, DateTime> GetKeyForItem(Student item)
        {
            return Tuple.Create<string, string, int, DateTime>(item.firstName, item.secondName, item.personalCode, item.birthDate);
        }
    }
}
