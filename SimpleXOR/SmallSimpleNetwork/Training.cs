using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallSimpleNetwork
{
    public class Training
    {
        private Network Net;

        /// <summary>
        /// Train the network towards a specific desired output
        /// </summary>
        /// <param name="ExpectedOutput">An array of output values we are looking for</param>
        /// <param name="net">The network that we want to train on</param>
        public void TrainThis(double[] ExpectedOutput, Network net)
        {
            Net = net;

            // start by calculating
            CalculateErrors(ExpectedOutput);

            // THEN adjust the weights when all the calculations are done
            AdjustWeights();
        }

        private void CalculateErrors(double[] ExpectedOutput)
        {
            // calculate output error
            for (int i = 0; i < Net.OutputLayer.Neurons.Count; i++)
            {
                // outputError1 = sigmoid(output1) * (expected1 - output1)
                Net.OutputLayer.Neurons[i].Error = Sigmoid.derivative(Net.OutputLayer.Neurons[i].Output) * (ExpectedOutput[i] - Net.OutputLayer.Neurons[i].Output);
            }

            // calculate hidden error
            for (int i = 0; i < Net.HiddenLayer.Neurons.Count; i++)
            {
                // reset the error since we will be adding the error values together
                Net.HiddenLayer.Neurons[i].Error = 0;

                for (int j = 0; j < Net.OutputLayer.Neurons.Count; j++)
                {
                    // add together the error of each output neuron connected to the specified hidden neuron
                    // hiddenError1 = ( sigmoid(hiddenOutput1) * outputError1 * outputConnection1weight1 ) + ( sigmoid(hiddenOutput1) * outputError2 * outputConnection2weight1 ) + ...
                    Net.HiddenLayer.Neurons[i].Error += Sigmoid.derivative(Net.HiddenLayer.Neurons[i].Output) * Net.OutputLayer.Neurons[j].Error * Net.OutputLayer.Neurons[j].Inputs[i].Weight;
                }
            }
        }

        private void AdjustWeights()
        {
            // start by adjusting the output layer and its connections
            for (int i = 0; i < Net.OutputLayer.Neurons.Count; i++)
            {
                Net.OutputLayer.Neurons[i].AdjustWeights();
            }

            // then adjust the hidden layer and its connections
            for (int i = 0; i < Net.HiddenLayer.Neurons.Count; i++)
            {
                Net.HiddenLayer.Neurons[i].AdjustWeights();
            }
        }
    }
}
