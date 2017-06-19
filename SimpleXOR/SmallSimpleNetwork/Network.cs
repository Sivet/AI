using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallSimpleNetwork
{
    /// <summary>
    /// Main class of the Artificial Neural Network
    /// </summary>
    public class Network
    {
        // each layer is 'just' a list of neurons
        /// <summary>
        /// Contains a list of all the neurons in the input layer
        /// </summary>
        public NeuralLayer InputLayer;
        /// <summary>
        /// Contains a list of all the neurons in the hidden layer
        /// </summary>
        public NeuralLayer HiddenLayer;
        /// <summary>
        /// Contains a list of all the neurons in the output layer
        /// </summary>
        public NeuralLayer OutputLayer;

        // for making random numbers.....
        private Random randy;

        /// <summary>
        /// Makes the layers send their data through the network to calculate their outputs
        /// </summary>
        public void Pulse()
        {
            lock (this)
            {
                HiddenLayer.Pulse();
                OutputLayer.Pulse();
            }
        }

        /// <summary>
        /// Needed to initialize the network
        /// </summary>
        /// <param name="seed">Seed for the random numbers used for 'Bias' and 'Weight'</param>
        /// <param name="inputNeurons">Number of input neurons</param>
        /// <param name="hiddenNeurons">Number of hidden neurons</param>
        /// <param name="outputNeurons">Number of output neurons</param>
        public void Init(int seed, int inputNeurons, int hiddenNeurons, int outputNeurons)
        {
            InputLayer = new NeuralLayer();
            HiddenLayer = new NeuralLayer();
            OutputLayer = new NeuralLayer();

            randy = new Random(seed);

            // ceate all the neurons for each layer
            for (int i = 0; i < inputNeurons; i++)
            {
                InputLayer.Neurons.Add(new Neuron(0));
            }
            // more neurons
            for (int i = 0; i < hiddenNeurons; i++)
            {
                HiddenLayer.Neurons.Add(new Neuron(randy.NextDouble()));
            }
            // and more
            for (int i = 0; i < outputNeurons; i++)
            {
                OutputLayer.Neurons.Add(new Neuron(randy.NextDouble()));
            }

            // connect hidden layer to input layer
            for (int i = 0; i < hiddenNeurons; i++)
            {
                for (int j = 0; j < inputNeurons; j++)
                {
                    HiddenLayer.Neurons[i].Inputs.Add(new Connection(InputLayer.Neurons[j], randy.NextDouble()));
                }
            }

            // connect output layer to hidden layer
            for (int i = 0; i < outputNeurons; i++)
            {
                for (int j = 0; j < hiddenNeurons; j++)
                {
                    OutputLayer.Neurons[i].Inputs.Add(new Connection(HiddenLayer.Neurons[j], randy.NextDouble()));
                }
            }
        }
    }
}
