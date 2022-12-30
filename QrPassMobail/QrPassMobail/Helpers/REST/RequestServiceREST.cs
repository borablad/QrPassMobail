using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using QrPassMobail.Models;

using Xamarin.Essentials;

namespace QrPassMobail.Helpers.REST
{
    public class RequestServiceREST
    {

        public async Task<HttpResponseMessage> Post(string methodName, object requestParams, string mediaType = "application/json", bool IsImage = false)
        {
            var client = GetClient();

          
                //requestParams string
                return await client.PostAsync(string.Format(Constans.RestUrl, methodName),
                    new StringContent((string)requestParams, Encoding.Default, mediaType));
            
        }
      
        public async Task<HttpResponseMessage> Get(string methodName)
        {
            var client = GetClient();
            return await client.GetAsync(string.Format(Constans.RestUrl, methodName));
        }


        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var token = Preferences.Get("access_token", $"");
            var token_type = Preferences.Get("auth_scheme", $"Bearer");

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", $"{token_type} {token}");
            }

            return client;
        }
        public async Task<HttpResponseMessage> Delete(string methodName)
        {
            var client = GetClient();
            return await client.DeleteAsync(string.Format(Constans.RestUrl, methodName));
        }

        public async Task<HttpResponseMessage> Delete(string methodName, string requestParams)
        {
            var client = GetClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, string.Format(Constans.RestUrl, methodName));
            request.Content = new StringContent(requestParams, Encoding.UTF8, "application/json");
            return await client.SendAsync(request);
        }
    }
}
