using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR_NeuralNetwork
{
    class NeuralLayer
    {
        public List<Neuron> neurons = new List<Neuron>();

        public void Pulse(NeuralNet net)
        {
            foreach (Neuron neuron in neurons)
                neuron.Pulse(this);
        }
    }
}
