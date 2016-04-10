using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesFilter
{
    /// <summary>
    /// Simple Pipe, Do not store data.
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class GarbagePipe<T>: Pipe<T>
    {
        public GarbagePipe(): base(1)
        {

        }

        public new bool AddData(T data)
        {
            return true;
        }

    }
}
