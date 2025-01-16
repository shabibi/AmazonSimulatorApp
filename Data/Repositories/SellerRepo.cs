namespace AmazonSimulatorApp.Data.Repositories
{
    public class SellerRepo : ISellerRepo
    {
        public ApplicationDbContext _context;
        public SellerRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Seller> GetAllSellers()
        {
            try
            {
                return _context.Sellers.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }


        public Seller GetSellerById(int sid)
        {
            try
            {
                return _context.Sellers.FirstOrDefault(u => u.SID == sid);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        public void AddSeller(Seller seller)
        {
            try
            {
                _context.Sellers.Add(seller);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }


        public void UpdateSeller(Seller seller)
        {
            try
            {

                _context.Sellers.Update(seller);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }


        public void DeleteSeller(int sid)
        {
            try
            {
                var seller = GetSellerById(sid);
                if (seller != null)
                {
                    _context.Sellers.Remove(seller);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

    }
}
