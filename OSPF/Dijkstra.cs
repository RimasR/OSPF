using System.Collections.Generic;
namespace OSPF
{
    public class Dijkstra
    {

        private static char seperator = ';';

        // Dijkstra's algorithm to find shortest path from s to all other nodes
        public static Dictionary<string, string> dijkstra(NetworkGraph G, string source)
        {
            string[] routers = G.getEdges();
            int[] dist = new int[routers.Length]; 
            string[] queue = new string[routers.Length];
            Dictionary<string, string> pred = new Dictionary<string, string>(); 
            bool[] visited = new bool[routers.Length]; // all false initially

            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = int.MaxValue;
                queue[i] = routers[i];
                if (routers[i].Equals(source))
                {
                    dist[i] = 0;
                }
            }

            for (int i = 0; i < dist.Length; i++)
            {
                int next = minVertex(dist, visited);
                if (next != -1)
                {
                    visited[next] = true;
                    string[] neighbors = G.getNeighbors(routers[next]);
                    for (int j = 0; j < neighbors.Length; j++)
                    {
                        int nr = 0;
                        for (int h = 0; h < routers.Length; h++)
                        {
                            if (routers[h].Equals(neighbors[j]))
                            {
                                nr = h;
                            }
                        }
                        int d = dist[next] + G.getWeight(routers[next], routers[nr]);
                        if (dist[nr] > d)
                        {
                            dist[nr] = d;
                            queue[nr] = queue[next] + seperator + queue[nr];
                        }
                    }
                }
            }

            foreach (string str in queue)
            {
                string[] parts = str.Split(seperator);
                if (parts.Length != 1)
                {
                    pred[parts[parts.Length - 1]] = parts[1];
                }
                else
                {
                    pred[parts[0]] = parts[0];
                }
            }

            return pred;
        }

        private static int minVertex(int[] dist, bool[] v)
        {
            int x = int.MaxValue;
            int y = -1;
            for (int i = 0; i < dist.Length; i++)
            {
                if (!v[i] && dist[i] < x)
                {
                    y = i;
                    x = dist[i];
                }
            }
            return y;
        }

    }
}