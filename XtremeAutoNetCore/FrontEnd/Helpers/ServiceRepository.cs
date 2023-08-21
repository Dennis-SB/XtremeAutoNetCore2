using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;

namespace FrontEnd.Helpers
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }

        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5098");
            Client.DefaultRequestHeaders.Add("ApiKey", "LucppMEjwu1ISwX6h5GqabH1pKtSZnlWQXRTpipz2uwTKncSWSiL33BpPMyCfQiGUnUexkoiZodlkrtlmDb8RGX0t6o1XetD5jrgqV3kh2VpqdWccUHZSO2zR2nFBonsFm9rj6ljsvzap6b4rJcsnUvmiqj68lVdLW0GfIevfnoM4nNb1uBx3BXrAgNvdNt4pKKuftygx2yn89cWjzkaffHLzUWm1fa8UqxQ22TuBk7pNnSAIvyhtP2PSwdL6jUJ");
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}