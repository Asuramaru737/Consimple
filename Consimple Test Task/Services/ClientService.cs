using Consimple_Test_Task.Models;
using Consimple_Test_Task.Models.ResponseModels;
using Consimple_Test_Task.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consimple_Test_Task.Services
{
    public class ClientService : IClientService
    {
        private readonly ProjDbContext _dbContext;

        public ClientService(ProjDbContext context)
        {
            _dbContext = context;
        }

        public Client CreateClient(Client model)
        {
            var client = _dbContext.Clients.Find(model.Id);
            if (client != null)
                return client;

            client = new Client()
            {
                FullName = model.FullName,
                DateOfBirth = model.DateOfBirth.Date,
                DateOfRegistration = DateTime.Today.Date
            };
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return client;
        }

        public Client UpdateClient(Client model)
        {
            if (model == null)
                return null;
            var client = _dbContext.Clients.FirstOrDefault(x => x.Id == model.Id);

            client.FullName = model.FullName;

            _dbContext.SaveChanges();
            return client;
        }

        public Client? GetClient(int id)
        {
            if (_dbContext.Clients.Any(x => x.Id == id))
            {
                return _dbContext.Clients.First(x => x.Id == id);
            }

            return null;
        }

        public IEnumerable<Client>GetAllClients()
        {
            return _dbContext.Clients.Select(x => x).ToList();
        }

        public void DeleteClient(int id)
        {
            var client = GetClient(id);
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ClientDataResponseModel> FindByDateOfBirth(DateTime date)
        {
            return _dbContext.Clients
                .Where(x => x.DateOfBirth.Date == date.Date)
                .Select(x => new ClientDataResponseModel()
            {
                Id = x.Id,
                FullName = x.FullName
            }).ToList();
        }
    }
}
