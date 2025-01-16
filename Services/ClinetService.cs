using AmazonSimulatorApp.Data.Repositories;
using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public class ClinetService : IClinetService
    {
        public ClinetRepo _clinetRepo;
        public ClinetService(ClinetRepo clinetRepo)
        {
            _clinetRepo = clinetRepo;
        }


        public IEnumerable<Client> GetAllClients()
        {
            return _clinetRepo.GetAllClients();
        }


        public Client GetClinetById(int cid)
        {
            return _clinetRepo.GetClinetById(cid);
        }

        public void AddClient(Client client)
        {
            _clinetRepo.AddClient(client);
        }


        public void UpdateClient(Client client)
        {
            _clinetRepo.UpdateClient(client);
        }


        public void DeleteClient(int cid)
        {
            _clinetRepo.DeleteClient(cid);
        }
    }
}
