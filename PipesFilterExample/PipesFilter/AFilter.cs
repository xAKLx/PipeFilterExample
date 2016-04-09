using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PipesFilter
{
    /// <summary>
    /// Filter abstract class for implementation.
    /// </summary>
    public abstract class AFilter
    {
        /// <summary>
        /// Defines if the Filter is running.
        /// </summary>
        public bool Stopped { get; set; }

        /// <summary>
        /// Set Stpped ot false.
        /// </summary>
        public AFilter()
        {
            Stopped = false;
        }

        /// <summary>
        /// Run the process method until Stopped is true.
        /// </summary>
        public void Run()
        {
            while(!Stopped)
            {
                process();
            }
        }

        /// <summary>
        /// Process data.
        /// </summary>
        protected abstract void process();
    }
}
