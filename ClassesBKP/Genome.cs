using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Genome
    {
        public List<Neuron> neurons;
        public List<Connection> connections;

        private int nextNeuronId = 0;

        public Genome(int numInputs, int numOutputs, Genome gen = null)
        {
            if(gen == null)
            {
                CreateNewGenome(numInputs, numOutputs);
            }
        }

        public void CreateNewGenome(int numInputs, int numOutputs)
        {
            for (int i = 0; i < numInputs; i++)
            {
                AddNeuron(NodeType.Input);
            }
            for (int i = 0; i < numOutputs; i++)
            {
                int idOutput = AddNeuron(NodeType.Output);
                for (int j = 0; j < numInputs; j++)
                {
                    Neuron neuron = neurons[j];
                    connections.Add(new Connection(neuron.id, idOutput, RandomWeight()));
                }
            }
        }

        public int AddNeuron(NodeType type)
        {
            int nid = nextNeuronId++;
            neurons.Add(new Neuron(nid, NodeType.Input));
            return nid;
        }

        public double RandomWeight()
        {
            return Population.Random.NextDouble() * 2 - 1;
        }

        public static Genome CrossOver(Genome genomeA, Genome genomeB)
        {
            return null;
        }
    }
}
