using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace PublicAPI.Samples.Utils
{
    public class Utils
    {
        public static string ClientID {
            get {
                return ConfigurationManager.AppSettings["ClientID"];
            }
        }
        public static string ClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["ClientSecret"];
            }
        }
        public static string EndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["EndPoint"];
            }
        }
        public static string GetAppSettings(string Key) {
            return ConfigurationManager.AppSettings[Key];
        }

        public static string GetUrlWizardToken(string ReturnUrl) {
            string result = $"{EndPoint}/CreateToken/Index?ClientId={ClientID}&ClientSecret={ClientSecret}&ReturnUrl={ReturnUrl}";
            return result;
        }
        public static string GetRefreshToken(string Token) {
            string result = $"{EndPoint}/api/RefreshToken/Refresh?ClientId={ClientID}&ClientSecret={ClientSecret}&Token={Token}";
            return result;
        }

        public static string GetUrlDummy(string DummyName, string ID)
        {
            string result = $"{EndPoint}/api/{DummyName}/{ID}";
            return result;
        }
    }
}