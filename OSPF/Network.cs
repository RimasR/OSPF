using System;
using System.Collections.Generic;

namespace OSPF
{
    public class Network
    {

        private List<Router> routers;

        public Network()
        {
            routers = new List<Router>();
        }

        public virtual void AddRouter(string id)
        {
            routers.Add(new Router(id));
        }

        public virtual bool RemoveRouter(string id)
        {
            foreach (Router router in routers)
            {
                if (id.Equals(router.GetRouterId()))
                {
                    foreach (Router @var in router.GetNeighbors())
                    {
                        @var.RemoveRouter(router);
                    }
                    routers.Remove(router);
                    return true;
                }
            }
            return false;
        }

        public virtual bool AddLink(string source, string dest, int weight)
        {
            foreach (Router router1 in routers)
            {
                if (source.Equals(router1.GetRouterId()))
                {
                    foreach (Router router2 in routers)
                    {
                        if (dest.Equals(router2.GetRouterId()))
                        {
                            router1.AddLink(router2, weight);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public virtual bool RemoveLink(string source, string dest)
        {
            foreach (Router router1 in routers)
            {
                if (source.Equals(router1.GetRouterId()))
                {
                    foreach (Router router2 in routers)
                    {
                        if (dest.Equals(router2.GetRouterId()))
                        {
                            router1.RemoveLink(router2);
                            router2.RemoveLink(router1);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public virtual bool SendMessage(string source, string dest, string message)
        {
            foreach (Router router in routers)
            {
                if (source.Equals(router.GetRouterId()))
                {
                    new Message(router, dest, message);
                    return true;
                }
            }
            return false;
        }
    }
}