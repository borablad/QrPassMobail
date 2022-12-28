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
        Task<string> LoginAsync(UserDto user);
        Task VisitCode(int code);
        Task<List<Visits>> getMyVisits();

    }
}
