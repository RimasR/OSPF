using System.Threading;

namespace OSPF
{
    public class PacketSender
    {

        private Router dest;
        private Packet packet;

        public PacketSender(Router dest, Packet packet)
        {
            this.dest = dest;
            this.packet = packet;
            run();

        }

        public void run()
        {
            dest.ReceivePacket(packet);
        }
    }
}
