using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Webapp.Hubs;
using Drip.Webapp.Models;
using Drip.Application.Interfaces;

namespace Drip.Webapp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHubContext<CurrentWaterUsageHub> _hubContext;
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IHubContext<CurrentWaterUsageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository; 
        }


        public async Task<IActionResult> Index(CurrentWaterUsageViewModel model)
        {
           await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.Message);
                return View();
        }

    }
}
