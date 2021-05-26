using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drip.Application.Interfaces;
using Drip.Application.Entities;
using Drip.Webapp.Models.CategoryModels;

namespace Drip.Webapp.Controllers
{
    public class CategoryController : Controller
    {

        private Application.Logic.CategoryLogic _logic;

        public CategoryController(Application.Logic.CategoryLogic logic)
        {
            _logic = logic;
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateCategory(CreateCategoryViewModel model)
        {
            _logic.CreateCategory(model.CategoryName);
                
            return Redirect("SuccesfullCreation");
        }

        public IActionResult SuccesfullCreation()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult DeleteCategory()
        {
            return View();
        }
    }
}
