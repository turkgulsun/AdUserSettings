using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using AdUserSettings.Business.Abstract;
using AdUserSettings.Business.DTOs;
using AdUserSettings.DataAccess.Abstract;
using AdUserSettings.WebUI.Helpers;
using AdUserSettings.WebUI.Models.AdSettings;
using AdUserSettings.WebUI.Models.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdUserSettings.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogService _logService;
        private IMapper _mapper;
        
        public HomeController(ILogService logService, IMapper mapper)
        {
            _logService = logService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var userVM = new UserVM();

            return View(userVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserVM userVM)
        {
            if (!ModelState.IsValid)
            {
                var model = new UserVM();
                return View(model);
            }

            string userName = userVM.UserName;
            string messsage = "";

            
            try
            {
                using (var context = AdUserSettingsHelper.GetContext())
                {
                    using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName))
                    {
                        //User lock control
                        if (user.IsAccountLockedOut())
                        {
                            user.UnlockAccount();
                            messsage = "Hesabınızın kilidi kaldırılmıştır.";
                            ToLogDTo(userName, messsage, LogTypeHelper.Success);
                            TempData["UserMessage"] = messsage;
                        }
                        else
                        {
                            messsage = "Hesabınız kilitli değildir.";
                            ToLogDTo(userName, messsage, LogTypeHelper.Info);
                            TempData["UserMessage"] = messsage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messsage = ex.Message;
                ToLogDTo(userName, messsage, LogTypeHelper.Error);
                TempData["UserMessage"] = messsage;
            }

            return View();
        }

        public void ToLogDTo(string username, string message, LogTypeHelper logTypeHelper)
        {
            LogDTO logDTO = new LogDTO();
            logDTO.UserName = username;
            logDTO.Type = logTypeHelper.Value;
            logDTO.Message = message;
            logDTO.IPAddress = "";
            logDTO.CreationDate = DateTime.Now;

            _logService.Add(logDTO);
        }
    }
}