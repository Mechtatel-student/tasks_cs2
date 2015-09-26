using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Konstantin
{
    class Queue<T> : IPriorityQueue<T>, ICollection<Tuple<T,int>>
    {
        private List<LinkedList<T>> internalData = new List<LinkedList<T>>();

        public void Enqueue(T val, int priority)
        {
            if (priority < 0)
            {
                throw new IndexOutOfRangeException("priority must be greater then 0");
            }
            if (internalData.Count < priority)
            {
                for (int i = internalData.Count; i < priority; i++)
                {
                    internalData.Add(new LinkedList<T>());
                }
            }
            internalData[priority].AddLast(val);
        }

        public T Dequeue()
        {
            T firstVal;
            int index = 0;
            if (this.Count()==0)
            {
                throw new Exception();
            }
            for (int i = 0; i < internalData.Count; i++)
            {
                if (internalData[i].Count != 0)
                {
                    index = i;
                    break;
                }
            }
            firstVal = First();
            internalData[index].RemoveFirst();
            return firstVal;
        }

        public T First()
        {
            if (this.Count() == 0)
            {
                throw new Exception();
            }
            int index = 0;
            for (int i = 0; i < internalData.Count; i++)
            {
                if (internalData[i].Count != 0)
                {
                    index = i;
                    break;
                }
            }
            return internalData[index].First();
        }

        public T First(int priority)
        {
            if (priority > internalData.Count - 1 || priority < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return internalData[priority].First();
        }

        public T Last()
        {
            return internalData.Last().Last();
        }
        public T Last(int priority)
        {
            if (priority > internalData.Count - 1 || priority < 0||internalData[priority].Count==0)
            {
                throw new Exception();
            }
            return internalData[priority].Last();
        }

        public int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < internalData.Count; i++)
                {
                    count += internalData[i].Count;
                }
                return count;
            }
        }

        public int GetCount(int priority)
        {
            if (priority > internalData.Count - 1 || priority < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return internalData[priority].Count;
        }



        public void Add(Tuple<T, int> item)
        {
            Enqueue(item.Item1, item.Item2);
        }

        public void Clear()
        {
            internalData.Clear();
        }

        public bool Contains(Tuple<T, int> item)
        {
            bool contains = false;
            for (int i = 0; i < internalData.Count; i++)
            {
                if (internalData[i].Contains(item.Item1))
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }

        public void CopyTo(Tuple<T, int>[] array, int arrayIndex)
        {
            int iterator = arrayIndex;
            foreach (var item in this)
            {
                array[iterator] = item;
                iterator++;
            }
        }

        public bool IsReadOnly
        {
            get { return this.IsReadOnly; }
        }

        public bool Remove(Tuple<T, int> item)
        {
            return this.Remove(item);
        }

        public IEnumerator<Tuple<T, int>> GetEnumerator()
        {
            for (int i = 0; i < internalData.Count; i++)
            {
                foreach (var item in internalData[i])
                {
                    if (internalData[i].Count!=0)
                    {
                        yield return Tuple.Create(item, i);
                    } 
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}


