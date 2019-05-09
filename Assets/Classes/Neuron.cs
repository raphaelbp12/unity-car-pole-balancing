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

    class Neuron
    {
        public int id;
        public NodeType nodeType;

        public Neuron(int i, NodeType nType)
        {
            id = i;
            nodeType = nType;
        }
    }
}
