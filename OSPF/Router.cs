using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OSPF
{
    public class Router
    {
        private string id;
        private Dictionary<string, string> connections;
        private List<Router> neighbors;
        private NetworkGraph network;
        private List<int> packets;

        public Router(string id)
        {
            this.id = id;
            neighbors = new List<Router>();
            packets = new List<int>();
            network = new NetworkGraph(15); //kiek routeriu norim
            network.addEdge(id);
            connections = new Dictionary<string, string>();
            connections.Add(id, id);
        }

        public Dictionary<string, string> GetList()
        {
            return connections;
        }

        public string GetRouterId()
        {
            return id;
        }

        public void AddNeighbor(Router router)
        {
            neighbors.Add(router);
        }

        public Router[] GetNeighbors()
        {
            return neighbors.ToArray();
        }

        public NetworkGraph GetNetwork()
        {
            return network;
        }

        public void AddLink(Router router, int weight)
        {
            neighbors.Add(router);
            router.AddNeighbor(this);
            network.addEdge(router.GetRouterId());
            network.setLink(id, router.GetRouterId(), weight);
            ReceivePacket(GeneratePacket(router));
        }

        public void RemoveLink(Router router)
        {
            neighbors.Remove(router);
            network.removeLink(id, router.GetRouterId());
            ReceivePacket(new Packet(Packet.GetCounter(), id, network));
        }

        public void RemoveRouter(Router router)
        {
            neighbors.Remove(router);
            network.removeEdge(router.GetRouterId());
            ReceivePacket(new Packet(Packet.GetCounter(), id, network));
        }

        private Packet GeneratePacket(Router router)
        {
            NetworkGraph secondNetwork = router.GetNetwork();

            foreach(string edge in secondNetwork.getEdges())
            {
                network.addEdge(edge);
                foreach(string neighbor in secondNetwork.getNeighbors(edge))
                {
                    network.addEdge(neighbor);
                    network.setLink(edge, neighbor, secondNetwork.getWeight(edge, neighbor));
                }
            }

            return new Packet(Packet.GetCounter(), id, network);
        }

        private void SendPacket(Packet packet)
        {
            foreach (Router router in neighbors)
            {
                router.ReceivePacket(packet);
            }
        }

        public void ReceivePacket(Packet packet)
        {
            if (!packets.Contains(packet.GetNumber()))
            {
                packets.Add(packet.GetNumber());
                network = packet.GetNetwork();
                connections = Dijkstra.dijkstra(network, id);
                SendPacket(packet);
            }
        }

        public void SendMessage(string dest, string text)
        {
            Program.Write("Zinute '" + text + "' routeryje vardu - " + id);
            Thread.Sleep(5000);
            if (dest.Equals(id))
            {
                Program.Write("Zinute '" + text + " pasieke norima routeri vardu - " + id);
                Program.Write(" ");
            } else
            {
                string sendTo;
                connections.TryGetValue(dest, out sendTo);
                foreach(Router router in neighbors)
                {
                    if(sendTo != null && sendTo.Equals(router.GetRouterId()))
                    {
                        router.SendMessage(dest, text);
                        break;
                    }
                }
            }
        }
    }
}
