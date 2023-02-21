using BusinessModel;
using DataaccessLayer.Dependency.IDependency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataaccessLayer.Dependency
{
    public class CategoryDAL :ICategoryDAL
    {

        private readonly ProductDbContext _context;

        public CategoryDAL(ProductDbContext context)
        {
            _context = context;
        }

        public List<CategoryBO> CategoryList()
        {
            //return _context.Categories.ToList();

            List<CategoryBO> categoryBOList = new List<CategoryBO>();
            var categoryList = _context.Categories.ToList();
            foreach (var category in categoryList)
            {
                CategoryBO categoryBO = new CategoryBO();
                categoryBO.id = category.id;
                categoryBO.Category_Name = category.Category_Name;
                // Other properties

                categoryBOList.Add(categoryBO);
            }
            return categoryBOList;

        }

        public void AddCategory(CategoryBO categoryBO)
        {
            var cat = new Category()
            {
                Category_Name = categoryBO.Category_Name
            };
            _context.Categories.Add(cat);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var data = _context.Categories.Where(e => e.id == id).SingleOrDefault();
            _context.Categories.Remove(data);
            _context.SaveChanges();

        }

        public CategoryBO Edit(int id)
        {
            //return  _context.Categories.Where(e => e.id == id).SingleOrDefault();
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                var categorydetails = new CategoryBO()
                {
                    id = category.id,
                    Category_Name = category.Category_Name
                   

                };
                return categorydetails;
            }
            return null;

        }


        public void Update(CategoryBO categoryBO)
        {

            Category category = new Category();
            category.id = categoryBO.id;
            category.Category_Name = categoryBO.Category_Name;

            _context.Categories.Update(category);
            _context.SaveChanges();

        }
    }
}
