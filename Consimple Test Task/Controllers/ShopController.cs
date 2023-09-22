using Consimple_Test_Task.Models;
using Consimple_Test_Task.Services;
using Consimple_Test_Task.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consimple_Test_Task.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShopController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly IPurchaseService _purchaseService;

        public ShopController(IClientService clientService, IProductService productService, IPurchaseService purchaseService)
        {
            _clientService = clientService;
            _productService = productService;
            _purchaseService = purchaseService;
        }

        #region Client
        [HttpPost]
        public JsonResult AddClient(Client model)
        {
            var client = _clientService.CreateClient(model);
            return Json(Ok(client));
        }

        [HttpPut]
        public JsonResult UpdateClient(Client model)
        {
            var client = _clientService.UpdateClient(model);
            if (client == null)
                return Json(BadRequest());
            return Json(Ok(client));
        }

        [HttpGet]
        public JsonResult GetClient(int id)
        {
            var client = _clientService.GetClient(id);
            return Json(Ok(client));
        }

        [HttpDelete]
        public JsonResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return Json(Ok());
        }

        [HttpGet]
        public JsonResult GetClientsByBirthDay(DateTime dateOfBirth)
        {

            var listOfClients = _clientService.FindByDateOfBirth(dateOfBirth);
            return Json(Ok(listOfClients));
        }
        #endregion

        #region Product
        [HttpPost]
        public JsonResult AddProduct(Product model)
        {
            var product = _productService.CreateProduct(model);
            return Json(Ok(product));
        }

        [HttpPut]
        public JsonResult UpdateProduct(Product model)
        {
            var product = _productService.UpdateProduct(model);
            if (product == null)
                return Json(BadRequest());
            return Json(Ok(product));
        }

        [HttpDelete]
        public JsonResult DeleteProduct(Guid id)
        {
            _productService.DeleteProduct(id);
            return Json(Ok());
        }

        [HttpGet]
        public JsonResult GetProduct(Guid id)
        {
            var client = _productService.GetProductById(id);
            return Json(Ok(client));
        }
        #endregion

        [HttpPost]
        public JsonResult AddPurchase(int clientId, List<Product> listOfProducts)
        {
            var purchase = _purchaseService.CreatePurchase(clientId, listOfProducts);
            return Json(Ok(purchase));
        }

        [HttpDelete]
        public JsonResult DeletePurchase(Guid id)
        {
            _purchaseService.DeletePurchase(id);
            return Json(Ok());
        }
    }
}
