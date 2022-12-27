using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QrPassMobail.Models;
namespace QrPassMobail.Services.rest_and_interface
{
    public interface RestI
    {
        Task<string> LoginAsync(UserDto user);
        
    }
}
