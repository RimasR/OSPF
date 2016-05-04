using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OSPF
{
    class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network();

            int i = 1;

            switch (i)
            {
                case 1:
                    network.AddRouter("R2");
                    network.AddRouter("R3");
                    network.AddRouter("R4");
                    network.AddRouter("R5");
                    network.AddRouter("R6");
                    network.AddRouter("R7");
                    network.AddRouter("R8");

                    network.AddLink("R1", "R2", 5);
                    network.AddLink("R2", "R3", 4);
                    network.AddLink("R4", "R3", 2);
                    network.AddLink("R2", "R5", 1);
                    network.AddLink("R6", "R3", 9);
                    network.AddLink("R6", "R5", 1);
                    network.AddLink("R6", "R8", 2);
                    network.AddLink("R4", "R8", 3);
                    network.AddLink("R6", "R7", 6);
                    network.AddLink("R1", "R7", 4);

                    network.SendMessage("R4", "R1", "is R4 i R1");

                    network.AddLink("R4", "R8", 1);
                    network.SendMessage("R4", "R1", "is R4 i R1 geresnis");

                    network.AddLink("R4", "R8", 3);
                    network.SendMessage("R7", "R3", "is R7 i R3");

                    network.RemoveRouter("R6");
                    network.SendMessage("R7", "R3", "is R7 i R3 kitoks");

                    break;
                case 2:
                    break;

                default:
                    break;
            }

            Console.ReadLine();
        }

        public static void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
