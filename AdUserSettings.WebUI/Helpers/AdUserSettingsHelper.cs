using AdUserSettings.WebUI.Models.AdSettings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;



namespace AdUserSettings.WebUI.Helpers
{
    public class AdUserSettingsHelper
    {
        private static IConfiguration _configuration;
        private static AdSetting _adSetting;

        public static IConfiguration configuration { get; set; }
        public AdUserSettingsHelper()
        {
            _configuration = configuration;
            _adSetting = configuration.GetSection("AdSetting").Get<AdSetting>();
        }
        public static PrincipalContext GetContext()
        {
            PrincipalContext context = new PrincipalContext(ContextType.Domain, _adSetting.Domain, _adSetting.DomainUser, Decryption(_adSetting.DomainPass, "Caretta_1997"));
            return context;
        }

        #region EncryptiononMethod

        private static TripleDES CreateDES(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }
        public static byte[] Encryption(string PlainText, string key)
        {
            TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateEncryptor();
            byte[] input = Encoding.Unicode.GetBytes(PlainText);
            return ct.TransformFinalBlock(input, 0, input.Length);
        }

        public static string EncryptionBase64String(string PlainText, string key)
        {
            return Convert.ToBase64String(Encryption(PlainText, key));
        }

        public static string Decryption(string CypherText, string key)
        {
            byte[] b = Convert.FromBase64String(CypherText);
            TripleDES des = CreateDES(key);
            ICryptoTransform ct = des.CreateDecryptor();
            byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
            return Encoding.Unicode.GetString(output);
        }

        #endregion
    }
}
