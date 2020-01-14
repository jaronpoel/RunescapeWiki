using Interfaces.Logic;
using Models;


namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IGameAccountContext : ILogic<GameAccount>
    {
        GameAccount GetAccountByID(int id);
        GameAccount UpdateStats(GameAccount account);
    }
}