using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Encapsulation.Vladimir
{
    class PriorityQueue<T> : IPriorityQueue <T>, ICollection<Tuple<int,T>>
    {
        SortedList<int, Queue<T>> priorityQueue = new SortedList<int, Queue<T>>();
        
        private T first;
        private T last;
        
        public void Enqueue(T value, int priority)
        {
            if (!priorityQueue.ContainsKey(priority))
            {
                if (priorityQueue.Count == 0)
                {
                    first = value;
                }

                priorityQueue.Add(priority, new Queue<T>());
                priorityQueue[priority].Enqueue(value);
            }
            else
            {
                priorityQueue[priority].Enqueue(value);
            }
            
            last = value;
        }

        public T Dequeue()
        {
            try
            {
                int maxKey = 0;
                for (int i = 0; i < priorityQueue.Count; i++)
                {
                    if (!priorityQueue.ContainsKey(maxKey))
                    {
                        maxKey++;
                    }
                }
                return priorityQueue[maxKey].Dequeue();
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty.", e);
            }
        }


        public T First()
        {
            try
            {
                return first;
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty.", e);
            }
        }

        public T First(int priority)
        {
            try
            {
                return priorityQueue[priority].Peek();
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty.", e);
            }
        }

        public T Last()
        {
            try
            {
                return last;
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty.", e);
            }
        }

        public T Last(int priority)
        {
            try
            {
                return priorityQueue[priority].Last();
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty.", e);
            }
        }

        public int GetCount(int priority)
        {
            return priorityQueue[priority].Count(); 
        }


        public void Add(Tuple<short, T> item)
        {   
            if (!priorityQueue.ContainsKey(item.Item1))
            {
                priorityQueue.Add(item.Item1, new Queue<T>());
                priorityQueue[item.Item1].Enqueue(item.Item2);
            }
            else
            {
                priorityQueue[item.Item1].Enqueue(item.Item2);
            }
        }
        //-------------------------------------
        public void Clear()
        {
           priorityQueue.Clear();
        }


        public bool Contains(Tuple<int, T> item)
        {       
            return (priorityQueue[item.Item1].Contains(item.Item2)) ? true : false; 
        }

        public void CopyTo(Tuple<int, T>[] array, int arrayIndex)
        {
            try
            {
                int index = 0;
                Tuple<int, T>[] workArray = new Tuple<int, T>[priorityQueue.Count];
                foreach (var workElement in priorityQueue)
                {
                    workArray[index] = new Tuple<int, T>(workElement.Key, workElement.Value.Peek());
                    index++;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Queue is empty.", e);
            }
        }


        public int Count
        {
            get
            {
                int summ = 0;
                int summ1 = 0;
                if (priorityQueue.Count != 0)
                {   
                    foreach (var workPriority in priorityQueue)
                    {
                        summ1 += workPriority.Value.Count;
                        foreach (var value in workPriority.Value)
                        {
                            summ ++;
                        }
                    }
                }
            return summ;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Tuple<int, T> item)
        {
            bool isRemove = false;
            if (priorityQueue.ContainsKey(item.Item1))
            {
                priorityQueue.Remove(item.Item1);
                isRemove = true;
            }
            return isRemove;
        }

        public IEnumerator<Tuple<int, T>> GetEnumerator()
        {
            foreach (var workPriority in priorityQueue)
            {
                foreach (var value in workPriority.Value)
                {
                    yield return new Tuple<int, T>(workPriority.Key, value);
                }
            }


        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Tuple<int, T> item)
        {
            throw new NotImplementedException();
        }
    }

}
