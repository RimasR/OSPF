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
            network.AddRouter("R1");
            network.AddRouter("R2");
            network.AddRouter("R3");
            network.AddRouter("R4");
            network.AddRouter("R5");
            network.AddRouter("R6");
            network.AddRouter("R7");
            network.AddRouter("R8");

            network.AddLink("R1", "R2", 2);
            network.AddLink("R2", "R3", 3);
            network.AddLink("R3", "R7", 9);
            network.AddLink("R3", "R5", 4);
            network.AddLink("R7", "R4", 7);
            network.AddLink("R4", "R6", 8);
            network.AddLink("R5", "R6", 5);
            network.AddLink("R1", "R6", 6);


            while (i == 1)
            {
                Console.WriteLine("1. Prideti routeri"
                                    + Environment.NewLine +"2. Prideti rysi "
                                    + Environment.NewLine +"3. Pasalinti routeri  " 
                                    + Environment.NewLine +"4. Pasalinti rysi "
                                    + Environment.NewLine +"5. Siusti zinute " 
                                    + Environment.NewLine +"6. Perziureti lentele " 
                                    + Environment.NewLine +"7. Exit");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Routerio vardas: ");
                        string name = Console.ReadLine();
                        if (network.AddRouter(name))
                        {
                            Console.WriteLine("Idetas routeris");
                        }
                        break;
                    case "2":
                        Console.Write("Pirmas routeris: ");
                        string first = Console.ReadLine();
                        Console.Write("Antras routeris: ");
                        string second = Console.ReadLine();
                        Console.Write("Svoris tarp routeriu: ");
                        string weight = Console.ReadLine();
                        if(network.AddLink(first, second, int.Parse(weight)))
                        {
                            Console.WriteLine("Pridetas rysys");
                        }
                        break;
                    case "3":
                        Console.Write("Routerio vardas: ");
                        string router = Console.ReadLine();
                        if (network.RemoveRouter(router))
                        {
                            Console.WriteLine("Isimtas routeris");
                        }
                        break;
                    case "4":
                        Console.Write("Pirmas routeris: ");
                        string first1 = Console.ReadLine();
                        Console.Write("Antras routeris: ");
                        string second1 = Console.ReadLine();
                        if(network.RemoveLink(first1, second1))
                        {
                            Console.WriteLine("Isimtas rysys tarp routeriu");
                        }
                        break;
                    case "5":
                        Console.Write("Pirmas routeris: ");
                        string source = Console.ReadLine();
                        Console.Write("Antras routeris: ");
                        string destination = Console.ReadLine();
                        Console.Write("Zinute: ");
                        string msg = Console.ReadLine();
                        if(network.SendMessage(source, destination, msg))
                        {
                            Console.WriteLine("Zinute issiusta");
                        }
                        break;
                    case "6":
                        Console.Write("Routerio vardas: ");
                        string routeris = Console.ReadLine();
                        Dictionary<string, string> conn = network.GetList(routeris);
                        if(conn != null)
                        {
                            foreach (string element in conn.Keys)
                            {
                                string getter;
                                conn.TryGetValue(element, out getter);
                                Console.WriteLine("Destination: " + element + " Send to: " + getter);
                            }
                        }
                        break;
                    case "7":
                        i = 0;
                        break;
                    default:
                        Console.WriteLine("Bloga ivestis!");
                        break;
                }
            }
        }

        public static void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
