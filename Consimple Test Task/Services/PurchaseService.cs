using Consimple_Test_Task.Models;
using Consimple_Test_Task.Models.ResponseModels;
using Consimple_Test_Task.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Consimple_Test_Task.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ProjDbContext _dbContext;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public PurchaseService(ProjDbContext dbContext, IClientService clientService, IProductService productService)
        {
            _dbContext = dbContext;
            _clientService = clientService;
            _productService = productService;
        }

        public Purchase CreatePurchase(int clientId, List<Product> listOfProducts)
        {
            int total = 0;
            var client = _clientService.GetClient(clientId);
            List<Product> list = new List<Product>();

            foreach (var item in listOfProducts)
            {
                total += item.Price;
                list.Add(_productService.GetProductById(item.Id));
            }
            
            var purchase = new Purchase()
            {
                Date = DateTime.Today.Date,
                Client = client,
                TotalPrice = total,
            };

            list.ForEach(x => x.Purchases.Add(purchase));

            _dbContext.Purchases.Add(purchase);
            _dbContext.SaveChanges();

            return purchase;
        }

        public void DeletePurchase(Guid id)
        {
            var purchase = _dbContext.Purchases.FirstOrDefault(x => x.Id == id);
            _dbContext.Purchases.Remove(purchase);
            _dbContext.SaveChanges();
        }
    }
}
