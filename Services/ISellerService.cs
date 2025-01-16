using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public interface ISellerService
    {
        void AddSeller(Seller seller);
        void DeleteSeller(int sid);
        IEnumerable<Seller> GetAllClients();
        Seller GetSellerById(int sid);
        void UpdateSeller(Seller seller);
    }
}