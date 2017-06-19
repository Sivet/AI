using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallSimpleNetwork
{
        class Connection
        {
            // weight between two connected neurons
            internal double Weight { get; set; }
            // used to get output from: Input.Output
            internal Neuron Input { get; set; }

            // when initializing the network
            internal Connection(Neuron input, double weight)
            {
                this.Input = input;
                this.Weight = weight;
            }
        }
}
