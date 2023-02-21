using BusinessModel;
using DataaccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Dependency.IDependency
{
    public interface IProductBL
    {

        List<ProductBO> GetProductList();

        ProductBO getProductDetails(int? Id);

        void ProductCreate(ProductBO productBO);

        void ProductEdit(ProductBO productBO);

        void ProductDelete(ProductBO productBO);

        bool ProductExists(int Id);

      
       
    }
}
