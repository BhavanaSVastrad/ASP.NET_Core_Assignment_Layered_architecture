using BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataaccessLayer.Dependency.IDependency
{
    public interface IProductDAL
    {
        List<ProductBO> getProductList();

        ProductBO getProductDetails(int? Id);

        void ProductCreate(ProductBO productBO);

        void ProductEdit(ProductBO productBO);

        void ProductDelete(ProductBO productBO);

        bool ProductExists(int Id);

       
    }
}
