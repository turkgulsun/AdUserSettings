using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdUserSettings.WebUI.Models.SmsRequests
{
    public class SmsRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Source_Addr { get; set; }
        public Message[] Messages { get; set; }
    }

    public class Message
    {
        public string Msg { get; set; }
        public string Dest { get; set; }

        public Message() { }

        public Message(string msg, string dest)
        {
            this.Msg = msg;
            this.Dest = dest;
        }
    }
}
