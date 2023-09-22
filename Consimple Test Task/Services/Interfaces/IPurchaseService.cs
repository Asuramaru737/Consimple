using Consimple_Test_Task.Models;

namespace Consimple_Test_Task.Services.Interfaces
{
    public interface IPurchaseService
    {
        Purchase CreatePurchase(int clientId, List<Product> model);
        void DeletePurchase(Guid id);
    }
}
