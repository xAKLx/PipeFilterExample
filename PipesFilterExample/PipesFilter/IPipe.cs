using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesFilter
{
    interface IPipe<T>
    {
        bool AddData(T data);
        T getData();
    }
}
