using BIMFace.SDK.CSharp.Sample.Web.NetCore31.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Diagnostics;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Web.NetCore31.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IBasicApi basicApi = new BasicApi();
            AccessTokenResponse accessTokenResponse = basicApi.GetAccessToken(GlobalContext.BIMFaceConfig.BIMFACE_AppKey, GlobalContext.BIMFaceConfig.BIMFACE_AppSecret);

            IFileManagementApi fileManagementApi = new FileManagementApi();
            var fileManagementResponse = fileManagementApi.GetHubs(accessTokenResponse.Data.Token);

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
