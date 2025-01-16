using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public interface IClinetService
    {
        void AddClient(Client client);
        void DeleteClient(int cid);
        IEnumerable<Client> GetAllClients();
        Client GetClinetById(int cid);
        void UpdateClient(Client client);
    }
}