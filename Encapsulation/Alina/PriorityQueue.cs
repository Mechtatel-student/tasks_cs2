using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Alina
{
    class PriorityQueue<T> : IPriorityQueue<T>, ICollection<Tuple<int, T>>
    {
        SortedDictionary<int, Queue<T>> myQueue = new SortedDictionary<int, Queue<T>>();
        public void Enqueue(T val, int priority)
        {
            if (!myQueue.ContainsKey(priority))
            {
                myQueue.Add(priority, new Queue<T>());
            }
            myQueue[priority].Enqueue(val);
        }

        public T Dequeue()
        {
            try
            {
                return myQueue.First().Value.Dequeue();
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty. There is no value in queue", e);
            }
        }

        public T First()
        {
            try
            {
                return myQueue.First().Value.Peek();
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty. There is no value in queue", e);
            }
        }

        public T First(int priority)
        {
            if (!myQueue.ContainsKey(priority) || myQueue[priority].Count == 0)
            {
                throw new Exception("There is no value with such priority");
            }
            return myQueue[priority].Peek();
        }

        public T Last()
        {
            try
            {
                return myQueue.Last().Value.ElementAt(myQueue.Last().Value.Count - 1);
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty. There is no value in queue", e);
            }
        }

        public T Last(int priority)
        {
            if (!myQueue.ContainsKey(priority) || myQueue[priority].Count == 0)
            {
                throw new Exception("There is no value with such priority");
            }
            return myQueue[priority].Last();
        }

        public int Count
        {
            get { return myQueue.Values.Sum(q => q.Count); }
        }

        public int GetCount(int priority)
        {
            return myQueue[priority].Count;
        }

        public void Add(Tuple<int, T> item)
        {
            if (!myQueue.ContainsKey(item.Item1))
            {
                myQueue.Add(item.Item1, new Queue<T>());
            }
            myQueue[item.Item1].Enqueue(item.Item2);
        }
        public bool Remove(Tuple<int, T> item)
        {
            bool isRemoved = false;
            if (myQueue.ContainsKey(item.Item1))
            {
                myQueue.Remove(item.Item1);
                isRemoved = true;
            }
            return isRemoved;
        }
        public bool Contains(Tuple<int, T> item)
        {
            return myQueue.Values.Any(x => x.Contains(item.Item2));
        }

        public void CopyTo(Tuple<int, T>[] array, int arrayIndex)
        {
            int count = 0;
            Tuple<int, T>[] tuple = new Tuple<int, T>[myQueue.Values.Sum(q => q.Count)];
            foreach (var item in myQueue)
            {
                tuple[count] = new Tuple<int, T>(item.Key, item.Value.Peek());
                count++;
            }
        }
        public void Clear()
        {
            myQueue.Clear();
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public IEnumerator<Tuple<int, T>> GetEnumerator()
        {
            foreach (var key in myQueue)
            {
                foreach (var value in key.Value)
                {
                    yield return new Tuple<int, T>(key.Key, value);
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

