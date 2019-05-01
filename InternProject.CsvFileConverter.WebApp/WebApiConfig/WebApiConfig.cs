using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace InternProject.CsvFileConverter.WebApp.WebApiConfig
{
    public class DealsApi
    {
        private const string ApiBaseUri = "http://localhost:61686/";

        public HttpClient Initial()
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiBaseUri) };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }


    }
}