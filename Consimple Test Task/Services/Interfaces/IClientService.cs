using Consimple_Test_Task.Models;
using Consimple_Test_Task.Models.ResponseModels;

namespace Consimple_Test_Task.Services.Interfaces
{
    public interface IClientService
    {
        Client CreateClient(Client model);
        Client UpdateClient(Client model);
        Client? GetClient(int id);
        IEnumerable<Client> GetAllClients();
        void DeleteClient(int id);
        IEnumerable<ClientDataResponseModel> FindByDateOfBirth(DateTime date);
    }
}
