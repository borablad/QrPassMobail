using System;
using System.Collections.Generic;
using System.Text;

namespace QrPassMobail.Helpers
{
    public static class Constans
    {
        public static string HostUrl = "192.168.31.62";
        public static string Scheme = "http";
        public static string Port = "8000";
   
        public static string RestUrl = $"{Scheme}://{HostUrl}:{Port}/{{0}}";

        public static string GetQr = "/Visit/GainQr";
        public static string Login = "Auth/Token";

        public static string Register = "User/Register";
        #region Visits
        public static string Visits = "/Visits";
        public static string SendCodeVisit = "/Visits/";
   
        #endregion
    }
}
