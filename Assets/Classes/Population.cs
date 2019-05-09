using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Population
    {
        public List<Genome> population = new List<Genome>();
        public int popSize;

        public static Random Random = new Random();

        private int numInputs;
        private int numOutputs;

        public Population(int size, int numInps, int numOutps)
        {
            popSize = size;
            numInputs = numInps;
            numOutputs = numOutps;

            for (int i = 0; i < size; i++)
            {
                Genome genome = new Genome(numInps, numOutps);
                population.Add(genome);
            }
        }
    }
}
