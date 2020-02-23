using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Poker
{
    class NetworkManager
    {
        TcpListener listener;
        TcpClient client;
        int port;

        public NetworkManager()
        {
            port = 7779;
            listener = new TcpListener(IPAddress.Any, port);
            connections = new List<string>();
        }

        public string Recive()
        {
            string outstring;
            listener.Start();
            client = listener.AcceptTcpClient();

            byte[] byteMessage = new byte[256];
            int byteNum = client.GetStream().Read(byteMessage, 0, byteMessage.Length);
            outstring = Encoding.Unicode.GetString(byteMessage, 0, byteNum);

            client.Close();
            listener.Stop();

            return outstring;
        }

        public bool Send(string ipDestination, string message)
        {
            IPAddress adress;
            client = new TcpClient();
            client.NoDelay = true;
            if (!IPAddress.TryParse(ipDestination, out IPAddress adressSet))
            {
                Console.WriteLine("Unable To Connect!");
                Console.WriteLine("Invalid IP.");
                Console.ReadKey();
                return false;
            } else
            {
                adress = adressSet;
            }

            try
            {
                client.Connect(adress, port);
            }
            catch
            {
                Console.WriteLine("Unable To Connect!");
                Console.WriteLine("IP is not a Host.");
                Console.ReadKey();
                return false;
            }

            if (client.Connected)
            {
                byte[] byteMessage = Encoding.Unicode.GetBytes(message);
                client.GetStream().Write(byteMessage, 0, byteMessage.Length);
                client.Close();
            }
            return true;
        }

        public string GetIp => Dns.GetHostAddresses(Dns.GetHostName())[1].ToString();

        public string GetNameC => Dns.GetHostName();

        /*
        public string GetIP()
        {
            
            string ip = "";

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                ip = endPoint.Address.ToString();
            }

            return ip; // 
        }
        */

        public void Setup()
        {
            bool connectSuccsses = false;
            while (!connectSuccsses)
            {
                Console.Clear();
                Console.Title = "SetUp";

                Console.WriteLine("Connect ([Q]/[Any]) | Host: [E] | Offline [O] | Exit: [Escape]");
                switch (Console.ReadKey().Key)
                {
                    default:
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.Write("Connect To: ");
                        if (Send(Console.ReadLine(), GetIp))
                        {
                            Program.MainConnect();
                            connectSuccsses = true;
                        }
                        break;

                    case ConsoleKey.E:
                        bool lobby = true;
                        while (lobby)
                        {
                            Console.Clear();
                            Console.WriteLine("Lobby IP: " + GetIp);
                            Connect(Recive());

                            foreach (string s in connections)
                            {
                                Console.WriteLine(s);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Wait For More Players? Yes [Q], No [E]/[Any]");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.Q:
                                    break;

                                default:
                                case ConsoleKey.E:
                                    lobby = false;
                                    break;
                            }
                            Console.ReadKey();
                        }

                        
                        Program.MainHost();
                        connectSuccsses = true;
                        break;

                    case ConsoleKey.O:
                        Program.MainOffline();
                        connectSuccsses = true;
                        break;

                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;
                }
            }
        }

        List<string> connections;
        List<string> Connections => connections;

        public void Connect(string ip)
        {
            connections.Add(ip);
        }

        public void Disconnect(string ip)
        {
            connections.Remove(ip);
        }
    }
}
