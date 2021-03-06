﻿using Interfaces.Logic;
using Models;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IGameAccountLogic : ILogic<GameAccount>
    {
        GameAccount GetAccountByID(int id);
        GameAccount UpdateStats(GameAccount account);
    }
}