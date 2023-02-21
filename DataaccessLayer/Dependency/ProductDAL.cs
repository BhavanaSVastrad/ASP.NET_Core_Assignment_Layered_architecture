using BusinessModel;
using DataaccessLayer.Dependency.IDependency;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataaccessLayer.Dependency
{
    public class ProductDAL : IProductDAL
    {
        private readonly ProductDbContext _context;



        public ProductDAL(ProductDbContext context)
        {
            _context = context;
        }

        public List<ProductBO> getProductList()
        {
            List<ProductBO> productBOList = new List<ProductBO>();
            var productList= _context.Products.ToList();
            foreach (var product in productList)
            {
                ProductBO productBO = new ProductBO();
                productBO.Id = product.Id;
                productBO.Product_Image = product.Product_Image;
                productBO.Product_Description = product.Product_Description;
                productBO.Product_Name = product.Product_Name;
                productBO.Product_Price = product.Product_Price;
                // Other properties

                productBOList.Add(productBO);
            }
            return productBOList;

        }

        public ProductBO getProductDetails(int? Id)
        {
            var product = _context.Products.Find(Id);
            if(product !=null)
            {
                var productdetails = new ProductBO()
                {
                    Id = product.Id,
                    Product_Image=product.Product_Image,
                    Product_Name=product.Product_Name,
                    Product_Description=product.Product_Description,
                    Product_Price=product.Product_Price
                    
                };
                return productdetails;
            }
            return null;
        }

        public void ProductCreate(ProductBO productBO)
        {
            Product product = new Product();
            product.Id = productBO.Id;
            product.Product_Image = productBO.Product_Image;
            product.Product_Name = productBO.Product_Name;
            product.Product_Description = productBO.Product_Description;
            product.Product_Price = productBO.Product_Price;
            _context.Products.Add(product);

            _context.SaveChanges();

        }
        public void ProductEdit(ProductBO productBO)
        {
            Product product = new Product();
            product.Id = productBO.Id;
            product.Product_Image = productBO.Product_Image;
            product.Product_Name = productBO.Product_Name;
            product.Product_Description = productBO.Product_Description;
            product.Product_Price = productBO.Product_Price;

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void ProductDelete(ProductBO productBO)
        {
            var product = _context.Products.Find(productBO.Id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public bool ProductExists(int Id)
        {
            return _context.Products.Any(e => e.Id == Id);
        }

       

    }
}
