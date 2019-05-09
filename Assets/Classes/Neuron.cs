using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public enum NodeType
    {
        Input,
        Output,
        Hidden
    }

    public class Neuron
    {
        public int id;
        public NodeType nodeType;
        public List<Connection> inputs;
        public List<Connection> outputs;

        public Neuron(int i, NodeType nType)
        {
            id = i;
            nodeType = nType;
            inputs = new List<Connection>();
            outputs = new List<Connection>();
        }
    }
}
