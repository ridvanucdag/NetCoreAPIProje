using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class EfProductDal : IProductDal
    {
        List<Product> _product;

        //ctor yazıp tab'a iki kere basıyoruz
        public EfProductDal()
        {
            _product = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product { ProductId = 2, CategoryId = 2, ProductName = "Kamera", UnitPrice = 1000, UnitsInStock = 61 },
            new Product { ProductId = 3, CategoryId = 3, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 45 },
            new Product { ProductId = 4, CategoryId = 4, ProductName = "Bilgisayar", UnitPrice = 3000, UnitsInStock = 38 },
            new Product { ProductId = 5, CategoryId = 5, ProductName = "Masa", UnitPrice = 400, UnitsInStock = 21 },
            };
        }
        public void Add(Product product)
        {
            _product.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _product.FirstOrDefault(p => p.ProductId == product.ProductId);
            _product.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _product;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _product.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _product.FirstOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
