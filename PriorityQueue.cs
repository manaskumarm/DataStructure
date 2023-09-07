using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractise
{

    public class PriorityQueue
    {
        public List<int> list;
        public int Count { get { return list.Count; } }

        public PriorityQueue()
        {
            list = new List<int>();
        }

        public PriorityQueue(int count)
        {
            list = new List<int>(count);
        }


        public void Enqueue(int x)
        {
            list.Add(x);
            int i = Count - 1;

            while (i > 0)
            {
                int p = (i - 1) / 2;
                if (list[p] <= x) break;

                list[i] = list[p];
                i = p;
            }

            if (Count > 0) list[i] = x;
        }

        public int Dequeue()
        {
            int min = Peek();
            int root = list[Count - 1];
            list.RemoveAt(Count - 1);

            int i = 0;
            while (i * 2 + 1 < Count)
            {
                int a = i * 2 + 1;
                int b = i * 2 + 2;
                int c = b < Count && list[b] < list[a] ? b : a;

                if (list[c] >= root) break;
                list[i] = list[c];
                i = c;
            }

            if (Count > 0) list[i] = root;
            return min;
        }

        public int Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Queue is empty.");
            return list[0];
        }

        public void Clear()
        {
            list.Clear();
        }
    }

    //   public class PriorityQueue<T> where T : IComparable<T>
    //    {
    //        private readonly List<T> _pq = new List<T>();
    //        public void Enqueue(T item)
    //        {
    //            _pq.Add(item);
    //            BubbleUp();
    //        }
    //        public T Dequeue()
    //        {
    //            var item = _pq[0];
    //            MoveLastItemToTheTop();
    //            SinkDown();
    //            return item;
    //        }
    //        private void BubbleUp() // Implementation of the Min Heap Bubble Up operation
    //        {
    //            var childIndex = _pq.Count - 1;
    //            while (childIndex > 0)
    //            {
    //                var parentIndex = (childIndex - 1) / 2;
    //                if (_pq[childIndex].CompareTo(_pq[parentIndex]) >= 0)
    //                    break;
    //                Swap(childIndex, parentIndex);
    //                childIndex = parentIndex;
    //            }
    //        }
    //        private void MoveLastItemToTheTop()
    //        {
    //            var lastIndex = _pq.Count - 1;
    //            _pq[0] = _pq[lastIndex];
    //            _pq.RemoveAt(lastIndex);
    //        }
    //        private void SinkDown() // Implementation of the Min Heap Sink Down operation
    //        {
    //            var lastIndex = _pq.Count - 1;
    //            var parentIndex = 0;

    //            while (true)
    //            {
    //                var firstChildIndex = parentIndex * 2 + 1;
    //                if (firstChildIndex > lastIndex)
    //                {
    //                    break;
    //                }
    //                var secondChildIndex = firstChildIndex + 1;
    //                if (secondChildIndex <= lastIndex && _pq[secondChildIndex].CompareTo(_pq[firstChildIndex]) < 0)
    //                {
    //                    firstChildIndex = secondChildIndex;
    //                }
    //                if (_pq[parentIndex].CompareTo(_items[firstChildIndex]) < 0)
    //                {
    //                    break;
    //                }
    //                Swap(parentIndex, firstChildIndex);
    //                parentIndex = firstChildIndex;
    //            }
    //        }
    //        private void Swap(int index1, int index2)
    //        {
    //            var tmp = _pq[index1];
    //            _pq[index1] = _pq[index2];
    //            _pq[index2] = tmp;
    //        }
    //    }
}
