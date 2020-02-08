using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
namespace Helper
{
    //http://124.105.198.3:94/api/Projects/1
    public class SynchronousRequest
    {
        //
        HttpClient httpClient;
        /// <summary>
        ///
        /// </summary>
        /// <param name="Url">HTTP LOCATION</param>
        /// <param name="controller">Controller</param>
        /// <param name="format">SAMPLE: "application/json"</param>
        public SynchronousRequest(string Url)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Url);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            //ApiClient.
        }
        public string HttpRequest()
        {
            //ApiHelper ap = new ApiHelper();
            HttpResponseMessage response = null;
            response = httpClient.GetAsync("").Result;

            string responseString = "[]";
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                // by calling .Result you are synchronously reading the result
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var responseContent = response.Content;
                responseString = responseContent.ReadAsStringAsync().Result;
            }
            httpClient.Dispose();
            return responseString;
        }
    }
}