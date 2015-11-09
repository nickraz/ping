using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Ping
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int success = 0;
            int timeout = 1000;
            string ans = "";
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            PingReply reply;
            for (int i = 0; i < n; i++)
            {
                reply = ping.Send(IPAddress.Parse("10.250.0.102"), timeout);
                if (reply.Address != null)
                {
                    ans = String.Format("Адрес: {0}, TTL: {1}, Статус: {2}", reply.Address, reply.Options.Ttl, reply.Status);
                    success++;
                }
                else ans = "No ping";
                Console.WriteLine(ans);
                System.Threading.Thread.Sleep(timeout);
            }
            Console.WriteLine("Работа завершена");
            Console.WriteLine("Всего отправлено пакетов: {0}. Удачно: {1}. Потеряно: {2}", n, success, n-success);
            Console.ReadKey();
        }
    }
}
