using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Valeriya
{
    class PriorityQueue <T> : Encapsulation.IPriorityQueue <T>, ICollection<Tuple<int, T>>
    {
        List<Tuple<int, T>> priorityQueue;

        public PriorityQueue()
        {
            priorityQueue = new List<Tuple<int, T>>();
        }
        
        public Tuple<int, T> this[int elem]
        {
            get { return priorityQueue[elem]; }
            set { priorityQueue[elem] = value; }
        }

        public void Add(int priority, T value)
        {
            priorityQueue.Add(Tuple.Create(priority, value));
        }

        public int Count
        {
            get { return priorityQueue.Count; }
        }

        public T Dequeue()
        {
            T result = GetHighestPriorityElem().Item2;

            if (priorityQueue.Count == 0)
            {
                throw new EmptyQueueException("The queue is empty");
            }
              
            return result;
        }

        public void Enqueue(T val, int priority)
        {
            int index = 0;
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (priorityQueue[i].Item1 > priority)
                {
                    index = i;
                    break;
                }
            }

            priorityQueue.Insert(index, Tuple.Create(priority, val));
        }

        public T First()
        {
            return priorityQueue[0].Item2;
        }

        public T First(int priority)
        {
            T result = priorityQueue[0].Item2;
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (priorityQueue[i].Item1 == priority)
                {
                    result = priorityQueue[i].Item2;
                    break;
                }
            }

            return result;
        }

        public int GetCount(int priority)
        {
            int count = 0;
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (priorityQueue[i].Item1 == priority)
                {
                    count++;
                }
            }

            return count;
        }

        public T Last()
        {
            return priorityQueue[priorityQueue.Count - 1].Item2;
        }

        public T Last(int priority)
        {
            T result = priorityQueue[0].Item2;
            for (int i = priorityQueue.Count - 1; i >= 0; i--)
            {
                if (priorityQueue[i].Item1 == priority)
                {
                    result = priorityQueue[i].Item2;
                    break;
                }
            }

            return result;
        }

        Tuple<int, T> GetHighestPriorityElem()
        {
            Tuple<int, T> minElemInQueue = priorityQueue[0];
            for (int i = 0; i < priorityQueue.Count; i++)
            {
                if (priorityQueue[i].Item1 < minElemInQueue.Item1)
                {
                    minElemInQueue = priorityQueue[i];
                }
            }

            return minElemInQueue;
        }

        public void Add(Tuple<int, T> item)
        {
            priorityQueue.Add(item);
        }

        public void Clear()
        {
            priorityQueue.Clear();
        }

        public bool Contains(Tuple<int, T> item)
        {
            return priorityQueue.Contains(item);
        }

        public void CopyTo(Tuple<int, T>[] array, int arrayIndex)
        {
            priorityQueue.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get;
            private set;
        }

        public bool Remove(Tuple<int, T> item)
        {
            return priorityQueue.Remove(item);
        } 
        
        public IEnumerator<Tuple<int, T>> GetEnumerator()
        {
                foreach (Tuple<int, T> item in priorityQueue)
                    yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
 	        return this.GetEnumerator();
        }
    }
}
