using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSPF
{
    public class Packet
    {

        private static int counter = 0;
        private int number;
        private string sender;
        private NetworkGraph network;

        public Packet(int number, string sender, NetworkGraph network)
        {
            this.number = number;
            this.sender = sender;
            this.network = network;
        }

        public static int GetCounter()
        {
            return counter++;
        }

        public int GetNumber()
        {
            return number;
        }

        public string GetSender()
        {
            return sender;
        }

        public NetworkGraph GetNetwork()
        {
            return network;
        }
    }
}
