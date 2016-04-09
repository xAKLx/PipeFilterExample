using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class library that defines the components of a Pipes and Filter pattern
namespace PipesFilter
{
    /// <summary>
    /// Representative interface of a pipe.
    /// </summary>
    /// <typeparam name="T">Type of data.</typeparam>
    public interface IPipe<T>
    {
        /// <summary>
        /// Adds data to the pipe if possible.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>If possible true, else return false </returns>
        bool AddData(T data);

        /// <summary>
        /// Returns the oldest data.
        /// </summary>
        /// <returns>Data or null if not data</returns>
        T getData();
        
    }
}
