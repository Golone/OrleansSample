﻿using Demo.IGrain;
using Lib;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StatelessWebGo.Controllers
{
    public class HomeController : Controller
    {
        private IClientFactory clientFactory;
        public HomeController(IClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = clientFactory.GetClient();
            var actor = client.GetGrain<IHello>(0);
            var r = await actor.SayHello("Kiwi");
            return Content(r);
        }
    }
}
