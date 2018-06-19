using System;
using System.Net.Http;

namespace InternProject.CsvFileConverter.WebApp.Helper
{
    public class DealsApi
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:61686/");
            return Client;
        }
    }
}