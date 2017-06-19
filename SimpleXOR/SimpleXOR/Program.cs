using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            Program MyProgram = new Program();

            MyProgram.StartSmallSimpleWorkingMostly();
        }
        private void StartSmallSimpleWorkingMostly()
        {
            SmallSimpleNetwork.Network net = new SmallSimpleNetwork.Network();
            SmallSimpleNetwork.Training train = new SmallSimpleNetwork.Training();

            // network initialization values (FUCK seed = 2)
            int seed = 5, inputs = 2, hiddens = 2, outputs = 1;

            // init network
            net.Init(seed, inputs, hiddens, outputs);

            // input values for the XOR network
            double[,] input = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };

            // the output value we would like for each set of XOR inputs
            double[] output = { 0, 1, 1, 0 };

            // train XOR network this many times each
            int trainingSessions = 1000;

            // start training
            for (int i = 0; i < trainingSessions; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // set the input to train from
                    net.InputLayer.Neurons[0].Output = input[j, 0];
                    net.InputLayer.Neurons[1].Output = input[j, 1];

                    // run the inputs through the network to get an output
                    net.Pulse();

                    // print out current input and output to see how we are doing
                    Console.WriteLine("{0} xor {1} = {2}", input[j, 0], input[j, 1], net.OutputLayer.Neurons[0].Output);

                    // give the trainer the value we want it to work towards
                    train.TrainThis(new double[] { output[j] }, net);
                }
            }

            Console.WriteLine("Training done! Press a key to test network.");
            Console.ReadKey();

            // test if our trained network works
            for (int i = 0; i < 4; i++)
            {
                // set input to test for
                net.InputLayer.Neurons[0].Output = input[i, 0];
                net.InputLayer.Neurons[1].Output = input[i, 1];

                // pulse them through to get a calculated output
                net.Pulse();

                // print our result in the console
                Console.WriteLine("");
                Console.WriteLine("{0} xor {1} = {2}", input[i, 0], input[i, 1], net.OutputLayer.Neurons[0].Output);
            }

            // done
            Console.ReadKey();
        }
    }
}
