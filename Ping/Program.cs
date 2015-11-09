using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

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
            List<IPAddress> ips = new List<IPAddress>();
            /*ips.Add(IPAddress.Parse("10.250.0.101"));
            ips.Add(IPAddress.Parse("10.250.0.103"));
            ips.Add(IPAddress.Parse("10.250.0.104"));
            ips.Add(IPAddress.Parse("10.250.0.106"));
            ips.Add(IPAddress.Parse("10.250.0.109"));*/
            ips.Add(IPAddress.Parse("10.250.0.150"));

            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            PingReply reply;
            for (int ip_index = 0; ip_index < ips.Count; ip_index++)
            {

                for (int i = 0; i < n; i++)
                {
                    reply = ping.Send(ips[ip_index], timeout);
                    if (reply.Address != null)
                    {
                        ans = String.Format("Адрес: {0}, TTL: {1}, Статус: {2}", reply.Address, reply.Options.Ttl, reply.Status);
                        success++;
                    }
                    else ans = "No ping";
                    //Console.WriteLine(ans);
                    System.Threading.Thread.Sleep(timeout);
                }
                //Console.WriteLine("------");
            }
            //Console.WriteLine("Работа завершена");
            //Console.WriteLine("Всего отправлено пакетов: {0}. Удачно: {1}. Потеряно: {2}", n * ips.Count, success, n * ips.Count - success);
            if (success == 0)
            {
                var p = new ProcessStartInfo("cmd", "/r shutdown -f -s -t 60 -c \"Был обнаружен сбой сети. компьютер будет перезагружен через 60 сек. Вы можете отменить перезагрузку, запустив файл \\\"Отменить перезагрузку.bat\\\" на рабочем столе\"");
                p.CreateNoWindow = false;
                p.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                Process.Start(p);
            }
            //Console.ReadKey();
        }
    }
}