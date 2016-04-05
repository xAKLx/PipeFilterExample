using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesFilter
{
    /// <summary>
    /// Queue based Pipe implementation
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class Pipe<T> : IPipe<T>
    {
        private Queue<T> queue;

        private int capacity;

        public Pipe(int capacity)
        {
            this.capacity = capacity;
            queue = new Queue<T>(this.capacity);
        }

        bool IPipe<T>.AddData(T data)
        {
            if (queue.Count == capacity)
                return true;
            else
            {
                queue.Enqueue(data);
                return false;
            }
                
        }

        /// <summary>
        /// TODO catch exeption.
        /// </summary>
        /// <returns></returns>
        T IPipe<T>.getData()
        {

            return queue.Dequeue();
        }
    }
}
