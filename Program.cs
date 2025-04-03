using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanner
{
    internal class Program
    {
        private static string IPAddres = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Tarama türünü seçiniz");

            Console.WriteLine("Port Listesinden Taramak için (1)");
            Console.WriteLine("Gelişmiş Tarama Yapmak İçin (2)");

            int taramaSecimi = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (taramaSecimi)
            {
                case 1:
                    {
                        KullaniciBilgisi();
                        ListeTaramasi();
                    }
                    break;
                case 2:
                    {
                        KullaniciBilgisi();
                        GelismisTarama();
                    }
                    break;
                 
            }

            Console.ReadKey();
        }

        private static void KullaniciBilgisi()
        {
            Console.WriteLine("IP Adresi:");
            IPAddres = Console.ReadLine();
        }


        private static void ListeTaramasi()
        {
            Console.Clear();
            using (TcpClient tarama = new TcpClient())
            {
                foreach (int s in Ports)
                {
                    try
                    {
                        tarama.Connect(IPAddres, s);
                        Thread.Sleep(100);
                        Console.WriteLine($"[{s}]  || OPEN", Console.ForegroundColor = ConsoleColor.Green);
                    }
                    catch 
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"[{s}]  || CLOSED", Console.ForegroundColor = ConsoleColor.Red);
                    }
                }
            }
        }

        private static void GelismisTarama()
        {
            Console.Clear();
            using (TcpClient tarama = new TcpClient())
            {
                foreach (int s in Port())
                {
                    try
                    {
                        tarama.Connect(IPAddres, s);
                        Thread.Sleep(100);
                        Console.WriteLine($"[{s}]  || OPEN", Console.ForegroundColor = ConsoleColor.Green);
                    }
                    catch 
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"[{s}]  || CLOSED", Console.ForegroundColor = ConsoleColor.Red);

                    }
                }
            }
        }


        private static int[] Ports = new int[]
        {
20,         
21,
22,
23,
25,
53,
67,
68,
69,
80,
110,
119,
123,
137,
138,
139,
143,
161,
162,
179,
194,
389,
443,
445,
465,
514,
520,
587,
631,
636,
989,
990,
993,
995,
1080,
1433,
1434,
1521,
1723,
1812,
1813,
2049,
3306,
3389,
4145,
5060,
5061,
5272,
5432,
5900,
6379,
8080,
51372,
        };
        private static int[] Port()
        {
            var Ports = new int[78274];

            for (int i = 0; i < Ports.Length; i++)
            {
                Ports[i] = Ports[i] + i;
            }

            return Ports;
        }

    }
}
