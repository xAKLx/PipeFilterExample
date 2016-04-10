using PipesFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesFilterExample
{
    /// <summary>
    /// Split a list of T and send it through a specific pipe per condition.
    /// One T only goes through one pipe (the first true condition).
    /// </summary>
    /// <typeparam name="T">Type of data of the collection of data</typeparam>
    public class Condition2PipeFilter<T> : AFilter
    {
        public delegate bool ConditionValue(T value);
        private List<KeyValuePair<ConditionValue, IPipe<ICollection<T>>>> condition2Pipe;
        public IPipe<ICollection<T>> Input { get; set; }

        /// <summary>
        /// Creats the object with an input pipe.
        /// </summary>
        /// <param name="input">Pipe de entrada de informacion, no puede ser null.</param>
        /// <exception cref="ArgumentNullException.ArgumentNullException">Si input es null.</exception>
        public Condition2PipeFilter(IPipe<ICollection<T>> input)
        {
            if (input == null)
                throw new ArgumentNullException("Input pipe can't be null.");
            Input = input;
            condition2Pipe = new List<KeyValuePair<ConditionValue, IPipe<ICollection<T>>>>();
        }

        /// <summary>
        /// Adds an output pipe and a condition to be evaluated.
        /// </summary>
        /// <param name="condition">Needs to be true when you desire to let a value go through the pipe. This value Can't be null.</param>
        /// <param name="pipe">If the condition is true, a value goes through this pipe. This value Can't be null.</param>
        /// <returns>True if the pair has been added, else return false</returns>
        public bool addCondition2Pipe(ConditionValue condition, IPipe<ICollection<T>> pipe)
        {
            if(condition != null && pipe != null)
            {
                condition2Pipe.Add(new KeyValuePair<ConditionValue, IPipe<ICollection<T>>>(condition,pipe));
                return true;
            }
            
            return false;
        }

        protected override void process()
        {
            ICollection<T> data = null;
            data = Input.getData();

            if(data != null)
            {
                List<T> list;
                foreach (var pair in condition2Pipe)
                {
                    list = new List<T>();
                    foreach (var value in data)
                    {
                        if (pair.Key(value))
                        {
                            list.Add(value);
                            data.Remove(value);
                        }
                    }
                    while(!pair.Value.AddData(list));
                }
            }
            
        }
    }
}
