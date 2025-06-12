using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TradyGrade.DAL.BDD
{
    partial class Client
    {
        public Client()
        {
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile("app.json", false, true).Build();
            BaseUrl = config.GetConnectionString("baseURL");
            _httpClient = new HttpClient();
        }
    }
}
