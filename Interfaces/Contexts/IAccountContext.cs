using Interfaces.Logic;
using Models;


namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IAccountContext : ILogic<Account>
    {
        Account GetAccountByID(int id);
    }
}