using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR_NeuralNetwork
{
    class Neuron
    {
        //Neuron
        public double Output { get; set; }
        public double Sum { get; set; }
        public double Bias { get; set; } //De fleste bruger en Bias
        
        public List<Connection> Input = new List<Connection>();

        public Neuron(double Bias)
        {
            this.Bias = Bias;
        }
        public void Pulse(NeuralLayer layer)
        {
            Output = 0;

            foreach (Connection item in Input)
            {
                Output += item.Input.Output * item.Weight;
            }
            Output += Bias;
            Sum = Output;

            Output = ActivateFunction(Output);
        }
        public double ActivateFunction(double value) //Sigmoid
        {
            return 1.0f / (1.0f + (float)Math.Exp(-value));
        }
        public double GetOutput()
        {
            return Output;
        }
        public void SetOutput(double output)
        {
            Output = output;
        }
    }
}
