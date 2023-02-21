using DataaccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;

using BusinessLayer.Dependency.IDependency;
using BusinessModel;

namespace Core_Assignment.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

       
        private readonly INotyfService _notyf;

       
        private readonly IProductBL _iproductbl;

        public ProductController(IProductBL _iproductbl, INotyfService notyf)
        {

            _notyf = notyf;

            this._iproductbl = _iproductbl;
           

        }


        [Route("Product/Index")]

        public  IActionResult Index(string sortOrder, string search)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Product_Name desc" : "";

            var products = from s in _iproductbl.GetProductList() select s;

            products = products.Where(x => x.Product_Name == search || search == null);

            switch (sortOrder)
            {
                case "Product_Name desc":
                    products = products.OrderByDescending(s => s.Product_Name);
                    break;

                default:
                    products = products.OrderBy(s => s.Product_Name);
                    break;
            }
            return View( products.ToList());
            

        }

      

        // GET: Products/Details/5
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var product = _iproductbl.getProductDetails(Id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Product_Image,Product_Name,Product_Description,Product_Price")] ProductBO productBO)
        {
            if (ModelState.IsValid)
            {
                _iproductbl.ProductCreate(productBO);
                _notyf.Custom("Successfully inserted!!", 3, "lightgreen", "fa fa-plus");
                return RedirectToAction(nameof(Index));
            }
            return View(productBO);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var product = _iproductbl.getProductDetails(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, [Bind("Id,Product_Image,Product_Name,Product_Description,Product_Price")] ProductBO productBO)
        {
            if (Id != productBO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _iproductbl.ProductEdit(productBO);
                    _notyf.Custom("Successfully Updated!!", 3, "orange", "fa fa-home");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productBO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productBO);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var product = _iproductbl.getProductDetails(Id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {



            var product = _iproductbl.getProductDetails(Id);

            _iproductbl.ProductDelete(product);
            _notyf.Custom("Product Deleted !", 2, "red", "fa fa-trash");
            return RedirectToAction(nameof(Index));

        }

        private bool ProductExists(int Id)
        {
            return _iproductbl.ProductExists(Id);
        }
        public IActionResult Cards()
        {
           

            var products = from s in _iproductbl.GetProductList() select s;

           
            return View(products.ToList());


        }
    }
}

