using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdUserSettings.WebUI.Models.Users
{
    public class UserVM
    {
        [Required(ErrorMessage = "Required Field")]
        public string UserName { get; set; }
    }
}
