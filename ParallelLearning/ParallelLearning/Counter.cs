using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLearning
{
    public class Counter
    {
        public int loopCounter { get; set; }

        public override string ToString()
        {
            return loopCounter.ToString();
        }
    }
}
