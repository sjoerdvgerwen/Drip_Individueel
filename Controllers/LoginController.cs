using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Drip.Application.Entities;
using Drip.Application.Interfaces;
using Drip.Webapp.Models;




namespace Drip.Webapp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IloginRepository _loginRepository;


        public LoginController(IloginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            List<User> Users = _loginRepository.GetAllUsers();

            var viewModel = new LoginViewModel
            {
                users = Users
            };

            return View(viewModel);
        }

    }
}
