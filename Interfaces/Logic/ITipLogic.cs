using Interfaces.Logic;
using Models;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface ITipLogic : ILogic<Tip>
    {
        Tip GetTipByMonsterID(int id);
    }
}