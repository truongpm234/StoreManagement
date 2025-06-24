using BusinessObject;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var context = new MyStoreContext();

                listProducts = context.Products.Include(f=>f.Category).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return listProducts;
        }

        public static void SaveProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error saving product: " + e.InnerException?.Message ?? e.Message, e);
            }

        }

        public static void DeleteProduct(Product product)
        {
            var context = new MyStoreContext();
            try
            {
                var id = context.Products.SingleOrDefault(i => i.ProductId == product.ProductId);
                context.Products.Remove(id);
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static Product GetProductById(int id)
        {
            
                using var context = new MyStoreContext();

                return context.Products.FirstOrDefault(i => i.ProductId.Equals(id));
                    
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using var context = new MyStoreContext();

                context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
