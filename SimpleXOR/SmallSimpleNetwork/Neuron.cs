using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallSimpleNetwork
{
    public class Neuron
    {
        // the out put is grabbed by the connection to the next layer
        public double Output { get; set; }
        // added to the output and changed when error is calculated
        internal double Bias { get; set; }
        // set when the trainer calculated the error we had and used for adjustment
        internal double Error { get; set; }
        // a list of the connection we have
        internal List<Connection> Inputs = new List<Connection>();

        // bias is set by a random number in the network
        internal Neuron(double bias)
        {
            this.Bias = bias;
        }

        // pulse is called from the network to force each neuron in each layer to calculate their output
        internal void Pulse()
        {
            // reset first
            Output = 0;

            // go through our connections
            foreach (Connection item in Inputs)
            {
                // add the output from the neuron at the other end of our connection * the weight from the connection
                Output += item.Weight * item.Input.Output;
            }
            // add the bias last
            Output += Bias;

            // use sigmoid to finish calculating our output
            Output = Sigmoid.output(Output);
        }

        // use by training when it's done calculating the error of each neuron
        internal void AdjustWeights()
        {
            // adjust the bias
            Bias += Error;

            // adjust the weight of each connection we have
            foreach (var item in Inputs)
            {
                item.Weight += Error * item.Input.Output;
            }
        }
    }
}
