using BusinessLayer.Dependency.IDependency;
using BusinessModel;
using DataaccessLayer;
using DataaccessLayer.Dependency.IDependency;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dependency
{
    public class ProductBL : IProductBL
    {
        private readonly IProductDAL db;

      
        public ProductBL(IProductDAL db)
        {
            this.db = db;

         
        }
        public List<ProductBO> GetProductList()
        {
            return db.getProductList();
        }
        public ProductBO getProductDetails(int? Id)
        {
            return db.getProductDetails(Id);
        }
        public void ProductCreate(ProductBO productBO)
        {
            db.ProductCreate(productBO);

        }

        public void ProductEdit(ProductBO productBO)
        {
            db.ProductEdit(productBO);

        }

        public void ProductDelete(ProductBO productBO)
        {
            db.ProductDelete(productBO);

        }

        public bool ProductExists(int Id)
        {
            return db.ProductExists(Id);
        }

        

    }
}
