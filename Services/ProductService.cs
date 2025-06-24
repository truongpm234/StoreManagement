using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Repositories;
namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public void DeleteProduct(Product product)
        {
            _repository.DeleteProduct(product);
        }


        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
           return _repository.GetProducts();
        }

        public void SaveProduct(Product product)
        {
            _repository.SaveProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }
    }
}
