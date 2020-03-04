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
                        }
                        else
                        {
                            messsage = "Hesabınız kilitli değildir.";
                            ToLogDTo(userName, messsage, LogTypeHelper.Info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
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



        //public void Method()
        //{
        //    PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "domain.local", "domain_standart_user", "domain_standart_user_pass");
        //    UserPrincipal userPrincipal = null;
        //    string userName = "";
        //    //domain bilgileri sonradan olusturdugumuz bir classtir.
        //    //objesi uretilip icerisinde domainden aldigimiz verileri koyuyoruz.
        //    //bu objeyi ister bir metoda dönüş verebilir ister buton_click'inde kullanabilir
        //    //isterseniz de kullanmayabilirsiniz.
        //    AdUser adUser = new AdUser();
        //    try
        //    {
        //        userPrincipal = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, userName);
        //        adUser.isAccessSuccess = true;
        //    }
        //    catch
        //    {
        //        adUser.isAccessSuccess = false;
        //        return adUser;
        //    }
        //    if (userPrincipal == null)
        //    {
        //        adUser.isAccountFound = false;
        //        return adUser;
        //    }
        //    if (userPrincipal.SamAccountName == "")
        //    {
        //        adUser.isAccountFound = false;
        //        return adUser;
        //    }
        //    adUser.isAccountFound = true;
        //    adUser.DisplayName = userPrincipal.DisplayName;
        //    adUser.EmailAddress = userPrincipal.EmailAddress;
        //    adUser.LastPasswordSet = userPrincipal.LastPasswordSet.ToString();
        //    if (userPrincipal.Enabled != null)
        //    {
        //        if (userPrincipal.Enabled == true)
        //            adUser.IsActive = true;
        //        else
        //            adUser.IsActive = false;
        //    }
        //    else
        //        adUser.IsActive = false;
        //    if (userPrincipal.IsAccountLockedOut())
        //        adUser.IsLocked = true;
        //    else
        //        adUser.IsLocked = false;
        //    userPrincipal = null;
        //    principalContext = null;
        //}
    }
}