using AmazonSimulatorApp.Data;
using static AmazonSimulatorApp.Services.CurrentUserService;

namespace AmazonSimulatorApp.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private CurrentUser _currentUser;

        // Store the current user
        public void SetCurrentUser(CurrentUser user)
        {
            _currentUser = user;
        }

        // Retrieve the current user
        public CurrentUser GetCurrentUser()
        {
            return _currentUser;
        }

    }
}
