using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdUserSettings.WebUI.Models.AdSettings
{
    public class AdSetting
    {
        public string Domain { get; set; }
        public string LDAPUser { get; set; }
        public string LDAPPass { get; set; }
        public string DomainUser { get; set; }
        public string DomainPass { get; set; }
        public string LDAPPath { get; set; }
        public string PasswordCharset { get; set; }
        public string SMSPasswordLenght { get; set; }
    }
}
