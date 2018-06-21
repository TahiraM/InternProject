using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace InternProject.CsvFileConverter.WebApp.WebApiConfig
{
    public class DealsApi
    {
        private string _apiBaseURI = "http://localhost:61686/";
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseURI);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
  
        }

        
    }
}