using BusinessLayer;
using BusinessLayer.Dependency.IDependency;
using BusinessModel;
using DataaccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Assignment.Controllers
{
  [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryBL _icategoryBL;
       
        public CategoryController(ICategoryBL _icategoryBL)
        {
            this._icategoryBL = _icategoryBL;

        }

       
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CategoryList()
        {
            var data = _icategoryBL.CategoryList();

            return new JsonResult(data);
        }

       
        [HttpPost]
        public JsonResult AddCategory(CategoryBO categoryBO)
        {

            _icategoryBL.AddCategory(categoryBO);
            return new JsonResult("Data is Saved ");
        }

       
        public JsonResult Delete(int id)
        {
            _icategoryBL.Delete(id);
            return new JsonResult("Data is Deleted ");
        }

       
        public JsonResult Edit(int id)
        {
            var data = _icategoryBL.Edit(id);
            
            return new JsonResult(data);
        }

      
        [HttpPost]
        public JsonResult Update(CategoryBO categoryBO)
        {


            _icategoryBL.Update(categoryBO);
            return new JsonResult("Data is Updated ");
        }

    }
}
