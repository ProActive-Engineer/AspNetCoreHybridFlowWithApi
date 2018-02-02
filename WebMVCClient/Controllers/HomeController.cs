﻿using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebHybridClient;
using WebMVCClient.Models;

namespace WebMVCClient.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;

        public HomeController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            var result = await _apiService.GetApiDataAsync();

            ViewData["data"] = result.ToString();
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
