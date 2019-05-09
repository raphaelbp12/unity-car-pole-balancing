using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Classes
{
    public class Genome
    {
        public List<Neuron> neurons = new List<Neuron>();
        public List<Connection> connections = new List<Connection>();

        private int numInputs;
        private int numOutputs;

        private int nextNeuronId = 0;

        private double[] memoizedOutput;

        public Genome(int numInps, int numOutps, Genome gen = null)
        {
            if(gen == null)
            {
                numInputs = numInps;
                numOutputs = numOutps;
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
                    AddConnection(neuron.id, idOutput, RandomWeight());
                }
            }
        }

        public void AddConnection(int inp, int outp, double weight)
        {
            Connection connection = new Connection(inp, outp, weight);
            connections.Add(connection);
            neurons[inp].outputs.Add(connection);
            neurons[outp].inputs.Add(connection);
        }

        public int AddNeuron(NodeType type)
        {
            int nid = nextNeuronId++;
            neurons.Add(new Neuron(nid, type));
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

        public double[] EvaluateNeuralNetwork(double[] input)
        {
            if (input.Length != numInputs)
                throw new ArgumentException("Input length does not match neural network inputs");

            memoizedOutput = new double[nextNeuronId];
            for (int i = 0; i < nextNeuronId; i++)
                memoizedOutput[i] = double.NaN;
            double[] outputs = new double[numOutputs];
            for (int i = 0; i < numOutputs; i++)
            {
                int onid = numInputs + i;
                outputs[i] = CalcOutput(input, onid, 0);
            }
            return outputs;
        }

        public double CalcOutput(double[] inputs, int id, int depth)
        {
            // This is only allowed because the inputs are guaranteed to come first
            if (id < numInputs)
                return inputs[id];

            if (!double.IsNaN(memoizedOutput[id]))
                return memoizedOutput[id];

            if (neurons[id].inputs.Count == 0)
                throw new ArgumentException("Encountered intermediate/output neuron with no inputs!");

            double csum = 0;
            foreach (Connection connection in neurons[id].inputs)
            {
                Debug.Log(depth + " " + connection.input);
                double op = CalcOutput(inputs, connection.input, depth + 1);

                memoizedOutput[connection.input] = op;
                csum += op * connection.weight;
            }

            return Sigmoid(csum);
        }

        public double Sigmoid(double d)
        {
            return 1.0 / (1 + Math.Exp(-4.9 * d));
        }
    }
}
