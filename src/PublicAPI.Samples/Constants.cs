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

        public const string client_id = "cRkEid0UlzLt1hnNE9YzzKwz2miBjFDAXIOCAVFwrSfmwU7aM2";
        public const string client_secret = "zPAO8KyhaZ7aDPM5TCMtTK9OWc32JjDQkZG0lnsBgnGUjeRO7QvYeDszLgT1rgdJDjEzKxX3gF4b2ICtMEvZ8TlA1kmO1FYd4s7";
    }
}