using Interfaces.Logic;
using Models;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IUserLogic : ILogic<User>
    {
        void AuthenticatUser(string Username, string Password);
    }
}