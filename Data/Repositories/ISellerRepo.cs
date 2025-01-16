
namespace AmazonSimulatorApp.Data.Repositories
{
    public interface ISellerRepo
    {
        void AddSeller(Seller seller);
        void DeleteSeller(int sid);
        IEnumerable<Seller> GetAllSellers();
        Seller GetSellerById(int sid);
        void UpdateSeller(Seller seller);
    }
}