using NetworkUtility.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            return "Success: Ping Sent!";
        }

        public int AddPings(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;    
        }

        public PingOption GetPingOption(PingOption option)
        {
            
            if (string.IsNullOrWhiteSpace(option.Type))
                throw new ArgumentNullException();
            return option;  
        }

        public IEnumerable<PingOption> LastRecentPingOption()
        {
            IEnumerable<PingOption> result = new[]
            {
                new PingOption { Date = new DateTime(2022,2,12), Size = 1232, Type = "Ping"},
                new PingOption { Date = DateTime.Now,  Size = 2343, Type = "we"},
                new PingOption { Date = DateTime.Now,  Size = 122343532, Type = "wq" }
            };
           

            return result;
        } 
    }
}
