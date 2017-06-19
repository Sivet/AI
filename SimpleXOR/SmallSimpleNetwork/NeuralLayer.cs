using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallSimpleNetwork
{
    public class NeuralLayer
    {
        // a list of all the neurons in the given layer
        public List<Neuron> Neurons { get; internal set; }

        internal NeuralLayer()
        {
            Neurons = new List<Neuron>();
        }

        // used to make all the neurons calculate their output
        internal void Pulse()
        {
            // send a pulse for each neuron we got
            foreach (var item in Neurons)
            {
                item.Pulse();
            }
        }
    }
}
