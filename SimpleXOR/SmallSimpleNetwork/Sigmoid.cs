using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallSimpleNetwork
{
    class Sigmoid
    {
        // the standard sigmoid function
        // used when calculating the output of a neuron
        internal static double output(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        // the drevative of the sigmoid function
        // used when training
        internal static double derivative(double x)
        {
            return x * (1 - x);
        }
    }
}
