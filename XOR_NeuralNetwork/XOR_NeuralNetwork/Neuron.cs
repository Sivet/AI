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
        public double Error { get; set; }
        public double Bias { get; set; }
        public double Learningrate { get; set; }

        public List<Connection> Input = new List<Connection>();
        public List<double> Adjustments = new List<double>();

        public Neuron(double Bias, double Learningrate)
        {
            this.Bias = Bias;
            this.Learningrate = Learningrate;
        }
        public void Pulse(NeuralLayer layer)
        {
            Output = 0;
            foreach (Connection item in Input)
            {
                Sum += item.Input.Output * item.Weight;
            }
            Sum = Sum + Bias;
            Output = ActivateFunction(Sum);
        }
        public double ActivateFunction(double value) //Sigmoid
        {
            return 1.0f / (1.0f + (float)Math.Exp(-value));
        }
        public void AdjustWeights()
        {
            Bias += Error;
            for (int i = 0; i < Input.Count; i++)
            {
                Input[i].AdjustWeight(Adjustments[i] * Learningrate);
            }
            Adjustments.Clear();
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
