
namespace AmazonSimulatorApp.Data.Repositories
{
    public interface IClinetRepo
    {
        void AddClient(Client client);
        void DeleteClient(int cid);
        IEnumerable<Client> GetAllClients();
        Client GetClinetById(int cid);
        void UpdateClient(Client client);
    }
}