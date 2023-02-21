using BusinessLayer.Dependency.IDependency;
using BusinessModel;
using DataaccessLayer;
using DataaccessLayer.Dependency.IDependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dependency
{
    public class CategoryBL :ICategoryBL
    {

        private readonly ICategoryDAL db;


        public CategoryBL(ICategoryDAL db)
        {
            this.db = db;

        }
        

        public List<CategoryBO> CategoryList()
        {
            return db.CategoryList();

        }
        public void AddCategory(CategoryBO categoryBO)
        {
            db.AddCategory(categoryBO);

        }

        public void Delete(int id)
        {
            db.Delete(id);

        }

        public CategoryBO Edit(int id)
        {
            return db.Edit(id);


        }

        public void Update(CategoryBO categoryBO)
        {


            db.Update(categoryBO);

        }
    }
}
