using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFlowClientManual
{
    public static class Constants
    {
        public const string BaseAddress = "http://localhost:54498/core";
        public const string CallbackPath = "http://localhost:57288/callback";
        public const string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public const string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public const string TokenEndpoint = BaseAddress + "/connect/token";
        public const string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";
        public const string TokenRevocationEndpoint = BaseAddress + "/connect/revocation";

        public const string client_id = "2grVswCTdfiQ8fnT3czpj2IGfmkRSmjfQwcaOod2J0JdhHljDr";
        public const string client_secret = "6hMhXqzEKXVHmH5DFG3PMSyLfU5KmbN8fTDHhoMiNEFs7UWSRj3lQDSKuHBOONiugUtwTEj6GzbaxKMlnO2XWE6HHFSwBRqOkBl";
    }
}