using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitPrice=115,UnitsInStock=1},
                new Product{ProductId=3,CategoryId=3,ProductName="Telefon",UnitPrice=1215,UnitsInStock=5},
                new Product{ProductId=4,CategoryId=3,ProductName="Klavye",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=5,CategoryId=3,ProductName="Fare",UnitPrice=15,UnitsInStock=15},
            };
        }

        public void Add(Product product)
        {
           _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product ProductDeleted;
            ProductDeleted = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryid)
        {
         return   _products.Where(p => p.CategoryId == categoryid).ToList();
        }

        public void Update(Product product)
        {
            Product ProductUpdated;
            ProductUpdated = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            ProductUpdated.ProductName= product.ProductName;
            ProductUpdated.UnitPrice= product.UnitPrice;
            ProductUpdated.UnitsInStock= product.UnitsInStock;
            ProductUpdated.CategoryId= product.CategoryId;

        }
    }
}
