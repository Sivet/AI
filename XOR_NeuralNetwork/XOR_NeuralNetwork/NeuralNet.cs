using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR_NeuralNetwork
{
    class NeuralNet
    {
        public NeuralLayer InputLayer;
        public NeuralLayer HiddenLayer;
        public NeuralLayer OutputLayer;

        public void Pulse()
        {
            lock (this)
            {
                HiddenLayer.Pulse(this);
                OutputLayer.Pulse(this);
            }
        }
        public void Init(int seed, int inputNeurons, int hiddenNeurons, int outputNeurons)
        {
            InputLayer = new NeuralLayer();
            HiddenLayer = new NeuralLayer();
            OutputLayer = new NeuralLayer();
            Random rand = new Random(seed);

            int i, j;

            for (i = 0; i < inputNeurons; i++)
                InputLayer.neurons.Add(new Neuron(0, 0.5));

            for (i = 0; i < hiddenNeurons; i++)
                HiddenLayer.neurons.Add(new Neuron(rand.NextDouble(), 0.5));

            for (i = 0; i < outputNeurons; i++)
                OutputLayer.neurons.Add(new Neuron(rand.NextDouble(), 0.5));

            //Wire input together with the hidden layer
            for (i = 0; i < HiddenLayer.neurons.Count; i++)
            {
                for (j = 0; j < InputLayer.neurons.Count; j++)
                {
                    HiddenLayer.neurons[i].Input.Add(new Connection(InputLayer.neurons[j], rand.NextDouble()));
                }
            }

            //Wire output together with hidden layer
            for (i = 0; i < OutputLayer.neurons.Count; i++)
            {
                for (j = 0; j < HiddenLayer.neurons.Count; j++)
                {
                    OutputLayer.neurons[i].Input.Add(new Connection(HiddenLayer.neurons[j], rand.NextDouble()));
                }
            }
        }
    }
}
