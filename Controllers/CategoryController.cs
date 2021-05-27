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


        public IActionResult Create(CreateCategoryViewModel model)
        {
            if (model.CategoryName != null)
            {
                if (_logic.CreateCategory(model.CategoryName))
                {
                    return RedirectToAction("SuccesfullCreation", model);
                }
                else
                {
                    model.ProblemOccured = true;
                }
            }

            return View(model);
        }

        public IActionResult SuccesfullCreation(CreateCategoryViewModel model)
        {
            return View(model);
        }

        public IActionResult Delete(DeleteCategoryViewModel model)
        {
            List<Category> _categories = _logic.GetAllCategories();

            model.Categories = _categories;
            

            if(model.CategoryId != Guid.Empty)
            {
                _logic.DeleteCategory(model.CategoryId);
                return RedirectToAction("SuccesfullDelete", model);
            }

            return View(model);
        }

        public IActionResult SuccesfullDelete(DeleteCategoryViewModel model)
        {
            return View(model);
        }
    }
}
