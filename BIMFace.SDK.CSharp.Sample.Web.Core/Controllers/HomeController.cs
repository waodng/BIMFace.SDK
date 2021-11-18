using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using BIMFace.SDK.CSharp.Sample.Web.Core.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BIMFace.SDK.CSharp.Sample.Web.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            string url = "https://api.bimface.com/oauth2/token";
            string data = String.Empty;

            HttpMethod httpMethod = new HttpMethod("POST");
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, url);

            MemoryStream memoryStream = new MemoryStream();

            if (data != null)
            {
                StreamWriter streamWriter = new StreamWriter(memoryStream);
                streamWriter.Write(data);
                streamWriter.Flush();
                memoryStream.Position = 0;
            }

            request.Content = new StreamContent(memoryStream);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            request.Headers.Add("Authorization", "Basic eFpuVzJ5V2g1MXJCVkJJOXBZRldrbDdOVXczMXY0bnc6NURWbFEwMXpuVUtKcnRjTGNjQnRiVGpOWlZsOXNnejg=");

            HttpResponseMessage response = _httpClient.SendAsync(request).Result;//.ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string result = response.Content.ReadAsStringAsync().Result;


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
