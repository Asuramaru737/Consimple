using Consimple_Test_Task.Models;

namespace Consimple_Test_Task.Services.Interfaces
{
    public interface IProductService
    {
        Product CreateProduct(Product model);
        void DeleteProduct(Guid id);
        Product? UpdateProduct(Product model);
        Product? GetProductById(Guid productId);
    }
}
