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
        Random rando = new Random();
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }
        public void Run()
        {
            int seed = 5;

            net.Init(seed, 2, 4, 1);

            double high = .9;
            double low = .1;

            double[][] input = new double[4][];
            input[0] = new double[] { high, high }; // 11 = false
            input[1] = new double[] { high, low }; // 10 = true
            input[2] = new double[] { low, high }; // 01 = true
            input[3] = new double[] { low, low }; // 00 = false

            double[] output = new double[4];
            output[0] = low;
            output[1] = high;
            output[2] = high;
            output[3] = low;

            //Do Training

            PrintOut(0, 1); //true
            PrintOut(1, 0); //true
            PrintOut(0, 0); //false
            PrintOut(1, 1); //false

            Console.ReadKey();
        }
        private bool PrintOut(double input1, double input2)
        {
            bool result;

            net.InputLayer.neurons[0].SetOutput(input1);
            net.InputLayer.neurons[1].SetOutput(input2);

            net.Pulse();

            result = net.OutputLayer.neurons[0].GetOutput() > .5;

            Console.WriteLine("Input: " + input1 + " " + input2);
            Console.WriteLine("The actual result: " + result.ToString());
            Console.WriteLine(net.OutputLayer.neurons[0].GetOutput() + " % ");
            return result;
        }
    }
}
