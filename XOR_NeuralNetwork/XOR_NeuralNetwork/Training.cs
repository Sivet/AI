using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR_NeuralNetwork
{
    class Training
    {
        NeuralNet net;
        public double error { get; set; }
        public double deltaOutputSum { get; set; }
        public double[] deltaHiddenSum { get; set; }
        public double[] deltaWeightToOutput { get; set; }
        public double[] deltaWeightToHidden { get; set; }

        public void TrainAttempt1(double targetvalue, NeuralNet net)
        {
            this.net = net;
            
            //Udregn error
            error = targetvalue - net.OutputLayer.neurons[0].Output;

            //instantiere vectorer til resultatet
            deltaWeightToOutput = new double[net.OutputLayer.neurons[0].Input.Count];

            //Udregn outer til hidden weights
            deltaOutputSum = SigmoidDerivative(net.OutputLayer.neurons[0].Sum) * (error); //Ændring Sum til Output
            for (int i = 0; i < net.OutputLayer.neurons[0].Input.Count; i++)
            {
                deltaWeightToOutput[i] = deltaOutputSum * net.HiddenLayer.neurons[i].Output;
            }

            //instantiere vectorer til resultatet
            deltaHiddenSum = new double[net.HiddenLayer.neurons.Count];
            int weightCount = 0;
            for (int i = 0; i < net.HiddenLayer.neurons.Count; i++)
            {
                weightCount += net.HiddenLayer.neurons[i].Input.Count;
            }
            deltaWeightToHidden = new double[weightCount];

            //Udregn input til outer weights
            for (int i = 0; i < deltaHiddenSum[i]; i++)
            {
                deltaHiddenSum[i] = deltaOutputSum * net.OutputLayer.neurons[0].Input[i].Weight * SigmoidDerivative(net.HiddenLayer.neurons[i].Sum); //Ændring Sum til Output
            }
            int tempCount = 0;
            for (int j = 0; j < net.InputLayer.neurons.Count; j++)
            {
                for (int i = 0; i < deltaHiddenSum.Length; i++)
                {
                    deltaWeightToHidden[tempCount] = deltaHiddenSum[i] * net.InputLayer.neurons[j].Output;
                    tempCount++;
                }
            }
            //Change the weights of hidden to output
            for (int i = 0; i < deltaWeightToOutput.Count(); i++)
            {
                net.OutputLayer.neurons[0].Input[i].AdjustWeight(deltaWeightToOutput[i]);
            }
            //Change the weigths of input to hidden
            tempCount = 0;
            for (int i = 0; i < net.InputLayer.neurons.Count(); i++)
            {
                for (int j = 0; j < net.HiddenLayer.neurons.Count; j++)
                {
                    net.HiddenLayer.neurons[j].Input[i].AdjustWeight(deltaWeightToHidden[tempCount]);
                    tempCount++;
                }
            }

        }
        public void TrainAttempt2(int testNeuron, double targetOutput, NeuralNet net)
        {
            this.net = net;
            CalculateOutputError(testNeuron, targetOutput);
        }
        private void CalculateOutputError(int testNeuron, double targetOutput)
        {
            net.OutputLayer.neurons[testNeuron].Error = targetOutput - net.OutputLayer.neurons[testNeuron].Output;

            for (int i = 0; i < net.OutputLayer.neurons.Count; i++)
            {
                if (i == testNeuron)
                {
                    //Did this one
                }
                else
                {
                    net.OutputLayer.neurons[i].Error = 0 - net.OutputLayer.neurons[i].Output; //skal kigges
                }
            }
            CalculateHiddenError();
        }
        private void CalculateHiddenError()
        {
            for (int i = 0; i < net.HiddenLayer.neurons.Count; i++)
            {
                double error = 0;
                for (int j = 0; j < net.OutputLayer.neurons.Count; j++)
                {
                    error += net.OutputLayer.neurons[j].Error * net.OutputLayer.neurons[j].Input[i].Weight;
                }
                net.HiddenLayer.neurons[i].Error = error * SigmoidDerivative(net.HiddenLayer.neurons[i].Output);
            }
            AdjustOutputWeight();
        }
        private void AdjustOutputWeight()
        {
            for (int i = 0; i < net.OutputLayer.neurons.Count; i++)
            {
                double deltaOutputSum = SigmoidDerivative(net.OutputLayer.neurons[i].Output) * net.OutputLayer.neurons[i].Error;
                for (int j = 0; j < net.OutputLayer.neurons[i].Input.Count; j++)
                {
                    net.OutputLayer.neurons[i].Adjustments.Add(deltaOutputSum * net.HiddenLayer.neurons[j].Output);
                }
            }
            for (int x = 0; x < net.OutputLayer.neurons.Count; x++)
            {
                net.OutputLayer.neurons[x].AdjustWeights();
            }
            AdjustHiddenWeight();
        }
        private void AdjustHiddenWeight()
        {
            for (int i = 0; i < net.HiddenLayer.neurons.Count; i++)
            {
                for (int j = 0; j < net.HiddenLayer.neurons[i].Input.Count; j++)
                {
                    net.HiddenLayer.neurons[i].Adjustments.Add(net.HiddenLayer.neurons[i].Error * net.HiddenLayer.neurons[i].Input[j].Input.Output);
                }
            }
            for (int i = 0; i < net.HiddenLayer.neurons.Count; i++)
            {
                net.HiddenLayer.neurons[i].AdjustWeights();
            }
        }
        
        private double SigmoidDerivative(double value)
        {
            return value * (1.0 - value);
        }
    }
}