using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Connection
    {
        public int innovationNumber;
        public int input;
        public int output;
        public double weight;
        public bool disabled;

        private static int GlobalInnovationNumber = 0;
        private static List<Connection> connectionsHistory = new List<Connection>();

        public Connection(int inp, int outp, double weig, bool disab = false)
        {
            input = inp;
            output = outp;
            weight = weig;
            disabled = disab;

            checkHistory();
        }

        public void checkHistory()
        {
            Connection similarGene = null;

            foreach (Connection connection in connectionsHistory)
            {
                if (connection.input == input && connection.output == output)
                {
                    similarGene = connection;
                }
            }

            if(similarGene != null)
            {
                innovationNumber = similarGene.innovationNumber;
            }
            else
            {
                innovationNumber = GlobalInnovationNumber++;
                connectionsHistory.Add(this);
            }
        }
    }
}
