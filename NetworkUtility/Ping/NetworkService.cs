﻿using System;
using System.Collections.Generic;
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
    }
}
