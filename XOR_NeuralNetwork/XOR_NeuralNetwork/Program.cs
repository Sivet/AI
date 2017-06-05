using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR_NeuralNetwork
{
    class Program
    {
        NeuralNet net = new NeuralNet();
        Training train = new Training();
        Random rando = new Random();
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }
        public void Run()
        {
            int seed = 2;

            //net.Init(seed, 2, 3, 1);
            net.Init(seed, 2, 2, 2);

            double high = .9;
            double low = 0.01;

            double[][] input = new double[4][];
            input[0] = new double[] { high, high }; //1-1 = false
            input[1] = new double[] { high, low }; //1-0 = true
            input[2] = new double[] { low, high }; //0-1 = true
            input[3] = new double[] { low, low }; //0-0 = false

            double[] output = new double[4];
            output[0] = 0.01; //1-1 = false
            output[1] = 0.9; //1-0 = true
            output[2] = 0.9; //0-1 = true
            output[3] = 0.01; //0-0 = false

            for (int i = 0; i < 100; i++)
            {
                //PrintOut(input[0], output[0]);
                //PrintOut(input[1], output[1]);
                //PrintOut(input[2], output[2]);
                //PrintOut(input[3], output[3]);

                PrintOut2(input[0], output[0]);
                PrintOut2(input[1], output[1]);
                PrintOut2(input[2], output[2]);
                PrintOut2(input[3], output[3]);
            }

            Console.ReadKey();
        }
        private bool PrintOut(double[] input, double targetResult)
        {
            bool result;

            net.InputLayer.neurons[0].SetOutput(input[0]);
            net.InputLayer.neurons[1].SetOutput(input[1]);

            net.Pulse();
            train.TrainAttempt1(targetResult, net);

            result = net.OutputLayer.neurons[0].GetOutput() > .5;

            Console.WriteLine("Input: " + input[0] + " " + input[1]);
            Console.WriteLine("The actual result: " + result.ToString());
            Console.WriteLine(net.OutputLayer.neurons[0].GetOutput());
            return result;
        }
        private bool PrintOut2(double[] input, double targetResult)
        {
            bool result;
            int testNeuron;
            int notTestNeuron;

            net.InputLayer.neurons[0].SetOutput(input[0]);
            net.InputLayer.neurons[1].SetOutput(input[1]);

            net.Pulse();
            if (input[0] == input[1])
            {
                testNeuron = 0;
                notTestNeuron = 1;
            }
            else
            {
                testNeuron = 1;
                notTestNeuron = 0;
            }

            train.TrainAttempt2(testNeuron, targetResult, net);

            result = net.OutputLayer.neurons[testNeuron].GetOutput() > .5;

            Console.WriteLine("Input: " + input[0] + " " + input[1]);
            Console.WriteLine("Neuron 0 Output: " + net.OutputLayer.neurons[0].GetOutput());
            Console.WriteLine("Neuron 1 Output: " + net.OutputLayer.neurons[1].GetOutput());
            Console.WriteLine("Neuron 0 Error: " + net.OutputLayer.neurons[0].Error);
            Console.WriteLine("Neuron 1 Error: " + net.OutputLayer.neurons[1].Error);
            Console.WriteLine("");
            return result;
        }
    }
}
