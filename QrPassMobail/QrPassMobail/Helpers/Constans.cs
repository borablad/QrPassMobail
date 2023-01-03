using QrPassMobail.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QrPassMobail.Helpers
{
    public partial class Constans:BaseViewModel
    {
        #region Настройка серва
        /*        public static string HostUrl = "192.168.31.62";
                public static string Scheme = "http";
                public static string Port = "8000";*/

        public static string RestUrl = $"{Sheme}://{HostUrl}:{Port}/{{0}}";
        #endregion

        #region Login and Register
        public static string Login = "Auth/Token";

        public static string Register = "User/Register";
        #endregion
        #region Qr
        public static string GetQr = "Visit/GainQr";
        #endregion
        #region Visits
        public static string Visits = "Visits";
        public static string SendCodeVisit = "Visits/";
        public static string DeleteAllVisits = "/Visits/DeleteLegasy";

        #endregion
        #region Users
        public static string DeleteUser = "/User/Delete/";
        #endregion
    }
}
