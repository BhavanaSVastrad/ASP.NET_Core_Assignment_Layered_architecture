using BusinessModel;
using DataaccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dependency.IDependency
{
    public interface ICategoryBL
    {
        List<CategoryBO> CategoryList();

        void AddCategory(CategoryBO categoryBO);

        void Delete(int id);

        CategoryBO Edit(int id);

        void Update(CategoryBO categoryBO);
    }
}
