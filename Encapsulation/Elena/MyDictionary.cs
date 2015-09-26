using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Elena
{
    class MyDictionary:KeyedCollection<Tuple<string, string, DateTime, int>, Student>
    {
        protected override Tuple<string, string, DateTime, int> GetKeyForItem(Student item)
        {
            Tuple<string, string, DateTime, int> returnTuple = new Tuple<string, string, DateTime, int>(item.FirstName, item.LastName, item.BirthDay, item.personalCode);
            return returnTuple;
        }
    }
}
