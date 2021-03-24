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

        public IActionResult ShowUsers()
        {
            List<User> Users = _loginRepository.GetAllUsers();

            var viewModel = new LoginViewModel
            {
                users = Users
            };

            return View(viewModel);
        }

        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = _loginRepository.GetUserName(model.Username, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
