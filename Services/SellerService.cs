using AmazonSimulatorApp.Data.Repositories;
using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepo _sellerRepo;
        public SellerService(ISellerRepo sellerRepo)
        {
            _sellerRepo = sellerRepo;
        }


        public IEnumerable<Seller> GetAllClients()
        {
            return _sellerRepo.GetAllSellers();
        }


        public Seller GetSellerById(int sid)
        {
            return _sellerRepo.GetSellerById(sid);
        }

        public void AddSeller(Seller seller)
        {
            _sellerRepo.AddSeller(seller);
        }


        public void UpdateSeller(Seller seller)
        {
            _sellerRepo.UpdateSeller(seller);
        }


        public void DeleteSeller(int sid)
        {
            _sellerRepo.DeleteSeller(sid);
        }
    }
}
