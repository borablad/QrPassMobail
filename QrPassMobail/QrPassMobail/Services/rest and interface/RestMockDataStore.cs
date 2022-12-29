using Newtonsoft.Json;
using QrPassMobail.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QrPassMobail.Helpers;
using QrPassMobail.Helpers.REST;
using ZXing.QrCode.Internal;

namespace QrPassMobail.Services.rest_and_interface
{
    public class RestMockDataStore : RestI
    {

        #region Login and Register
        public async Task<string> LoginAsync(UserDto user)
        {
            var result = string.Empty;
            try
            {

                var request = JsonConvert.SerializeObject(user);

                var response = await new RequestServiceREST().Post(Constans.Login, request, "application/json");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    //result = JsonConvert.DeserializeObject<string>(responseData);
                    result = responseData.Replace("\"", "");
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<string> RegisterAsync(UserDto user)
        {
            var result = string.Empty;
            try
            {

                var request = JsonConvert.SerializeObject(user);

                var response = await new RequestServiceREST().Post(Constans.Register, request, "application/json");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    //result = JsonConvert.DeserializeObject<string>(responseData);
                    result = responseData.Replace("\"", "");
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        #endregion 
        #region Visits
        public async Task VisitCode(int code)
        {

            string result = "";
            try
            {


                var response = await new RequestServiceREST().Get(Constans.SendCodeVisit + $"?code={code}");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();



                }
                else
                {
                    result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
        public async Task<List<Visits>> getMyVisits()
        {
            var result = new List<Visits>();
            try
            {

               

                var response = await new RequestServiceREST().Get(Constans.Visits );
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Visits>>(responseData);
                   
                }
                else
                {

                    var responseData = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          

            return result;
        }
        #endregion
    }
}
