using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    public class MyDictionary : KeyedCollection <Tuple <string, string, int>, Student>
    {
        protected override Tuple<string, string, int> GetKeyForItem(Student item)
        {
            Tuple<string, string, int> myKey = new Tuple<string, string, int>(item.FirstName, item.LastName, item.PersonalCode);
            return myKey;
        }
    }
}
