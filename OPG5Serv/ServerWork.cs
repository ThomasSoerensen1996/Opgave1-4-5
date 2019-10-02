using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OBLBog;


namespace OPG5Serv
{
    public class ServerWork
    {

        private List<Bog> books = new List<Bog>()
        {
            new Bog("C# Bogen", "Peter", 444, "1780133594140"),
            new Bog("Thomaaaaa", "Anders", 555, "2780133594140")
        };

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);

            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tmpSocket = socket;
                    DoClient(tmpSocket);
                });
            }
        }

        private void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                bool forever = true;

                while (forever)
                {
                    string clientInput = sr.ReadLine();

                    switch (clientInput)
                    {
                        case "work":
                            sw.WriteLine("heej");
                            break;

                        case "HentAlle":
                            sw.WriteLine(JsonConvert.SerializeObject(books));
                            break;
                        case "Hent":
                            string isbn13 = sr.ReadLine();
                            Bog bog = books.Find(c => c.Isbn13 == isbn13);
                            sw.WriteLine(JsonConvert.SerializeObject(bog));
                            break;
                        case "Gem":
                            string gemData = sr.ReadLine();
                            Bog gemBog = JsonConvert.DeserializeObject<Bog>(gemData);
                            books.Add(gemBog);
                            break;
                            return;
                    }

                    sw.Flush();
                }
            }
        }

    }
}