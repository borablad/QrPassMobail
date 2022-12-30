using Newtonsoft.Json;
using QrPassMobail.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QrPassMobail.Helpers;
using QrPassMobail.Helpers.REST;
using ZXing.QrCode.Internal;
using Newtonsoft.Json.Linq;
using ZXing;

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

                    result = JObject.Parse(responseData)["access_token"].ToString();

                    result.Replace("\"", "");
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
                    return result;
                    var responseData = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<string>(responseData);
                   // result = responseData.Replace("\"", "");
                   
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
                    string rs = JObject.Parse(await response.Content.ReadAsStringAsync())["detail"].ToString();
                    
                    result = JsonConvert.DeserializeObject<List<Visits>>(rs);
                   
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


        public async Task<bool> DeleteAllVisits()
        {
            try
            {



                var response = await new RequestServiceREST().Delete(Constans.DeleteAllVisits);
                if (response.IsSuccessStatusCode)
                {
                    return true;

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
            return false;

        }


        #endregion

        #region users
        public async Task<bool> DeleteUser(string id)
        {
            try
            {



                var response = await new RequestServiceREST().Delete(Constans.DeleteUser + $"?userId={id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;

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
            return false;
        }
        #endregion
    }
}
