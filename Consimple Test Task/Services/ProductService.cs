using Consimple_Test_Task.Models;
using Consimple_Test_Task.Services.Interfaces;

namespace Consimple_Test_Task.Services
{
    public class ProductService : IProductService
    {
        private readonly ProjDbContext _dbContext;

        public ProductService(ProjDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product CreateProduct(Product model)
        {
            Product product;
            if (_dbContext.Products.Where(x => x.Name == model.Name).Any())
                product = _dbContext.Products.FirstOrDefault(x => x.Name == model.Name);
            else
            {
                product = new Product()
                {
                    Name = model.Name,
                    ItemNo = model.ItemNo,
                    Price = model.Price,
                    Category = model.Category,
                };

                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }
            return product;
        }

        public void DeleteProduct(Guid id)
        {
            var product = GetProductById(id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public Product? GetProductById(Guid productId)
        {
            if (_dbContext.Products.Any(x => x.Id == productId))
            {
                return _dbContext.Products.First(x => x.Id == productId);
            }

            return null;
        }

        public Product? UpdateProduct(Product model)
        {
            if (model == null)
                return null;
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == model.Id);

            product.Name = model.Name;
            product.ItemNo = model.ItemNo;
            product.Price = model.Price;
            product.Category = model.Category;

            _dbContext.SaveChanges();
            return product;
        }
    }
}
