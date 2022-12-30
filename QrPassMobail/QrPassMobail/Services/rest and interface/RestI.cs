using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QrPassMobail.Helpers;
using QrPassMobail.Models;
namespace QrPassMobail.Services.rest_and_interface
{
    public interface RestI
    {
        #region Login and Register
        Task<string> LoginAsync(UserDto user);
        Task<string> RegisterAsync(UserDto user);
        #endregion

        #region Visits
        Task VisitCode(int code);
        Task<List<Visits>> getMyVisits();
        Task<bool> DeleteAllVisits();
        #endregion

        #region Users
        Task<bool> DeleteUser(string id);
        #endregion


    }
}
