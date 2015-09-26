using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Elena
{
    
    public class PriorityQueue<T> :     IPriorityQueue<T>
                                    ,   ICollection<Tuple<int, T>>
    {
        private int  priority;
        private Queue<T> queueForPriority;
        public SortedSet<PriorityQueue<T>> OurSetWhithData=new SortedSet<PriorityQueue<T>>();//(new SortQueueByPriority());

        public int Priority
        {
            get { return priority; }
        }

        
        public PriorityQueue(int p, Queue<T> q)
        {
            priority = p;
            queueForPriority = q;
        }

        public void Enqueue(T val, int priority)
        {
            bool isPriorityExist = false;
            foreach (PriorityQueue<T> p in OurSetWhithData)
                
            {
                if (p.priority == priority)
                {
                    isPriorityExist = true;
                    p.queueForPriority.Enqueue(val);
                }
            }

            if (!isPriorityExist)
            {
                Queue<T> q = new Queue<T>();
                q.Enqueue(val);
                
                OurSetWhithData.Add(new PriorityQueue<T>(priority, q));
            }

           
        }

        public T Dequeue()
        {
           if(this.Count<=0)
           {
               throw new InvalidOperationException();
           }

           return OurSetWhithData.First<PriorityQueue<T>>().queueForPriority.Dequeue();
        }

        public T First()
        {
           if(this.Count<=0)
           {
               throw new InvalidOperationException();
           }
                return OurSetWhithData.First<PriorityQueue<T>>().queueForPriority.Peek();
           
        }

        public T First(int priority)
        {

            try
            {
                foreach (PriorityQueue<T> p in OurSetWhithData)
                {
                    if (p.priority == priority)
                    {
                        return p.queueForPriority.Peek();
                    }

                } throw new InvalidOperationException();
            }
            catch
            { throw new InvalidOperationException(); }
               
        }

        public T Last()
        {
           if(this.Count<=0)
           {
               throw new InvalidOperationException();
           }
                 return OurSetWhithData.Last<PriorityQueue<T>>().queueForPriority.Last<T>();
        }

        public T Last(int priority)
        {
            try
            {
                foreach (PriorityQueue<T> p in OurSetWhithData)
                {
                    if (p.priority == priority)
                    {
                        return  p.queueForPriority.Last<T>();
                    }

                } throw new InvalidOperationException();
            }
            catch
            { throw new InvalidOperationException(); }
            throw new InvalidOperationException();
        }

        public int Count
        {
            get 
            {
                int allCount=0;
                try
                {
                    foreach (PriorityQueue<T> p in OurSetWhithData)
                    {
                       
                            allCount += p.queueForPriority.Count();
                        
                    }
                }

                catch (InvalidOperationException)
                {  }
                return allCount;
            }
        }

        public int GetCount(int priority)
        {
            int countInThisQoueu=0;
            try
            {
                foreach (PriorityQueue<T> p in OurSetWhithData)
                {
                    if (p.priority == priority)
                    {
                        countInThisQoueu = p.queueForPriority.Count();
                    }
                }
            }
            catch (InvalidOperationException)
            { }
            return countInThisQoueu;
        }



        public void Add(Tuple<int, T> item)
        {
            this.Enqueue(item.Item2, item.Item1);
        }

        public void Clear()
        {
            while (this.Count > 0)
            {
                OurSetWhithData.Clear();
            }
        }

        public bool Contains(Tuple<int, T> item)
        {
            bool result = false;
            if (GetCount(item.Item1) > 0)
            {
                foreach (PriorityQueue<T> p in OurSetWhithData)
                {
                    if (p.priority == item.Item1)
                    {
                        result = p.queueForPriority.Contains(item.Item2);
                    }
                }
            }

            else
            {
                throw new InvalidOperationException();
            }
           
            return result;
        }

        public void CopyTo(Tuple<int, T>[] array, int arrayIndex)
        {
            int countOfArray=this.Count;
            for (int i = arrayIndex; i < countOfArray; i++)
            {
                array[i] = new Tuple<int, T>(1, this.Dequeue());
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Tuple<int, T> item)
        {
            bool isRemove = false;
            if (Contains(item))
            {
 
            }

            return isRemove;
        }

        public IEnumerator<Tuple<int, T>> GetEnumerator()
        {
            Tuple<int, T> t; //= new Tuple<int, T>(); 
            int priority;
            foreach (var p in this.OurSetWhithData)
            {
                priority = p.priority;
                foreach (var element in p.queueForPriority)
                {
                    t = new Tuple<int, T>(priority, element);
                    yield return t;
                }
            }


        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            Tuple<int, T> t; //= new Tuple<int, T>(); 
            int priority;
            foreach (var p in this.OurSetWhithData)
            {
                priority = p.priority;
                foreach (var element in p.queueForPriority)
                {
                    t = new Tuple<int, T>(priority, element);
                    yield return t;
                }
            }
        }
    }

   /* class SortQueueByPriority : IComparer<PriorityQueue<T>>
    {
        
        public int Compare(PriorityQueue<T> pq1, PriorityQueue<T> pq2)
        {
            int resultOfCompare = 0;
            if (pq1.Priority > pq2.Priority)
            { resultOfCompare = 1; }
            if (pq1.Priority < pq2.Priority)
            { resultOfCompare = -1; }
            return resultOfCompare;
        }


    }*/
}

