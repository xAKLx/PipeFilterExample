using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesFilter
{
    /// <summary>
    /// Filter that waits for a collection from all of his inputs to merge them.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MergerFilter<T> : AFilter
    {
        /// <summary>
        /// output pipe.
        /// </summary>
        private IPipe<ICollection<T>> outputPipe;

        /// <summary>
        /// Input pipes.
        /// </summary>
        private List<IPipe<ICollection<T>>> inputPipes;

        /// <summary>
        /// Set output pipe, value can't be null.
        /// </summary>
        /// <exception cref="ArgumentNullException.ArgumentNullException">If value is null.</exception>
        public IPipe<ICollection<T>> OutputPipe
        { get
            {
                return outputPipe;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value can't be null.");
                outputPipe = value;
            }
        }

        /// <summary>
        /// Creates the object with an output pipe.
        /// </summary>
        /// <param name="outputPipe">Output pipe, can't be null.</param>
        /// <exception cref="ArgumentNullException.ArgumentNullException">If outputPipe is null.</exception>
        public MergerFilter(IPipe<ICollection<T>> outputPipe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a input pipe.
        /// </summary>
        /// <param name="inputPipe">Input pipe to add, can't be null.</param>
        /// <returns>True if inputPipe has been added, else return false.</returns>
        public bool AddInputPipe(IPipe<ICollection<T>> inputPipe)
        {
            if (inputPipe != null)
            {
                inputPipes.Add(inputPipe);
                return true;
            }

            return false;
        }

        protected override void process()
        {
            var list = new List<T>();
            ICollection<T> data;
            foreach (var pipe in inputPipes)
            {
                do
                {
                    data = pipe.getData();
                }
                while (data == null);
                list.AddRange(data);
            }
            while (!OutputPipe.AddData(list)) ;
                
        }


    }
}
