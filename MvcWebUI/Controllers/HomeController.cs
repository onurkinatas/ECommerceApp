using Microsoft.AspNetCore.Mvc;
using MvcWebUI.ApiServices.Abstract;
using MvcWebUI.Models;
using System.Diagnostics;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiService _productApiService;

        public HomeController(ILogger<HomeController> logger, IProductApiService productApiService)
        {
            _logger = logger;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productApiService.GetProductsStatusTrue();
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}