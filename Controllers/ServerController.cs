using Drip.Webapp.Hubs;
using Drip.Webapp.Models;
using Drip.Webapp.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Drip.Webapp.Controllers
{
    public class ServerController : Controller
    {
        private readonly IHubContext<CurrentWaterUsageHub> _hubContext;

        public ServerController(IHubContext<CurrentWaterUsageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index(CurrentWaterUsageViewModel model)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.Message);
            return View();
        }

    }
}
