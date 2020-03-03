using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdUserSettings.WebUI.Models.AdSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdUserSettings.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private AdSetting _adSetting;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _adSetting= configuration.GetSection("AdSetting").Get<AdSetting>();
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(FormCollection collection)
        {
            return View();
        }
    }
}