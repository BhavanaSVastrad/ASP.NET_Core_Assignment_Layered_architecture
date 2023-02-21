using BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataaccessLayer.Dependency.IDependency
{
    public interface ICategoryDAL
    {
        List<CategoryBO> CategoryList();

        void AddCategory(CategoryBO categoryBO);

        void Delete(int id);

        CategoryBO Edit(int id);

        void Update(CategoryBO categoryBO);

    }
}
