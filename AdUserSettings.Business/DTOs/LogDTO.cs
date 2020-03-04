using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.Business.DTOs
{
    public class LogDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public string IPAddress { get; set; }
    }
}
