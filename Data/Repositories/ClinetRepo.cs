namespace AmazonSimulatorApp.Data.Repositories
{
    public class ClinetRepo : IClinetRepo
    {
        public ApplicationDbContext _context;
        public ClinetRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public IEnumerable<Client> GetAllClients()
        {
            try
            {
                return _context.Clients.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        
        public Client GetClinetById(int cid)
        {
            try
            {
                return _context.Clients.FirstOrDefault(u => u.CID == cid);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
        
        public void AddClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        
        public void UpdateClient(Client client)
        {
            try
            {

                _context.Clients.Update(client);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        
        public void DeleteClient(int cid)
        {
            try
            {
                var Client = GetClinetById(cid);
                if (Client != null)
                {
                    _context.Clients.Remove(Client);
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
