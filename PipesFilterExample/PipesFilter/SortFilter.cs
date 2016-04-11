using PipesFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesFilter
{
    /// <summary>
    /// Filter that receives a list of T, sort it and send it through an output pipe.
    /// </summary>
    /// <typeparam name="T">Type of data, must be comparable.</typeparam>
    public class SortFilter<T> : AFilter where T : IComparable<T>
    {
        private IPipe<ICollection<T>> inputPipe;
        private IPipe<List<T>> outputPipe;

        /// <summary>
        /// Get and Set the input pipe.
        /// </summary>
        /// <exception cref="ArgumentNullException.ArgumentNullException">If value is null.</exception>
        public IPipe<ICollection<T>> InputPipe
        {
            get { return inputPipe; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value can't be null.");
                inputPipe = value;
            }
        }

        /// <summary>
        /// Get and set the output pipe.
        /// </summary>
        /// <exception cref="ArgumentNullException.ArgumentNullException">If value is null.</exception>
        public IPipe<List<T>> OutputPipe
        {
            get { return outputPipe; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value can't be null.");
                outputPipe = value;
            }
        }

        /// <summary>
        /// Creates object with an input Pipe and an output Pipe.
        /// </summary>
        /// <param name="inputPipe">Input pipe, can't be null.</param>
        /// <param name="outputPipe">Output pipe, can't be null.</param>
        /// <exception cref="ArgumentNullException.ArgumentNullException">If either input or output pipe are null.</exception>
        public SortFilter(IPipe<ICollection<T>> inputPipe, IPipe<List<T>> outputPipe)
        {
            InputPipe = inputPipe;
            OutputPipe = outputPipe;
        }

        protected override void process()
        {
            ICollection<T> data;

            do
            {
                data = InputPipe.getData();
            } while (data == null);

            List<T> list = new List<T>();
            list.AddRange(data);
            list.Sort();

            while (!OutputPipe.AddData(list)) ;
        }
    }
}
