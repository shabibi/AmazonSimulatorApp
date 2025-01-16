using AmazonSimulatorApp.Data;

namespace AmazonSimulatorApp.Services
{
    public interface ICurrentUserService
    {
        CurrentUser GetCurrentUser();
        void SetCurrentUser(CurrentUser user);
    }
}