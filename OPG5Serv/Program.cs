using System;

namespace OPG5Serv
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerWork workserv = new ServerWork();
            workserv.Start();
            Console.Read();
        }
    }
}
