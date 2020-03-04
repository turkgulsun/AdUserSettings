using AdUserSettings.EntityFrameworkCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.Entities.Concrete
{
    public class Logs : IEntityFramework
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public string IPAddress { get; set; }
    }
}
