using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR_NeuralNetwork
{
    class Connection
    {
        public Neuron Input { get; set; }
        public double Weight { get; set; }

        public Connection(Neuron Input, double Weight)
        {
            this.Input = Input;
            this.Weight = Weight;
        }
        public void AdjustWeight() //skal have noget og udregne mængden den skal ændre sin weight
        {
        }
    }
}
