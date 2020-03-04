using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdUserSettings.WebUI.Models.AdUsers
{
    public class AdUser
    {
        public bool isAccessSuccess { get; set; }
        public bool isAccountFound { get; set; }
        public string NameSurname { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string LastPasswordSet { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
    }
}
