using AdUserSettings.WebUI.Models.AdSettings;
using AdUserSettings.WebUI.Models.SmsRequests;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AdUserSettings.WebUI.Functions
{

    public class SmsFunctions
    {
        private readonly IConfiguration _configuration;
        private readonly AdSetting _adSetting;
        public SmsFunctions(IConfiguration configuration)
        {
            _configuration = configuration;
            _adSetting = configuration.GetSection("AdSetting").Get<AdSetting>();
        }

        public static void SendSms(string message, string mobilePhone)
        {
            var sendMsg = new SmsRequest();
            sendMsg.UserName = "";
            sendMsg.Password = "";
            sendMsg.Source_Addr = "";
            sendMsg.Messages = new Message[] { new Message(message, mobilePhone) };

            string payload = JsonConvert.SerializeObject(sendMsg);

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            string campaign_id = wc.UploadString("http://sms.verimor.com.tr/v2/send.json", payload);
        }


        public string CreateSmsCode()
        {
            string code = "";

            Random rnd = new Random();
            string charset = _adSetting.PasswordCharset;
            for (int i = 0; i < int.Parse(_adSetting.SMSPasswordLenght); i++)
            {
                code += charset[rnd.Next(charset.Length)];
            }

            return code;
        }
    }
}
