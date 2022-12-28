using System;
using System.Collections.Generic;
using System.Text;

namespace QrPassMobail.Helpers
{
    public static class Constans
    {
        public static string HostUrl = "vendor.4dev.kz";
        public static string Scheme = "https";
        public static string Port = "443";
        public static string LisPort = "5000";
        public static string RestUrl = $"{Scheme}://{HostUrl}:{Port}/{{0}}";

        public static string GetQr = "/Visit/GainQr";
        public static string Login = "/Auth/Token";

        public static string Register = "/User/Register";
        #region Visits
        public static string Visits = "/Visits";
        public static string SendCodeVisit = "/Visits/";
   
        #endregion
    }
}
