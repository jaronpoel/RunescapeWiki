﻿using Models;


namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface ITipRepository : IRepository<Tip>
    {
        Tip GetTipByMonsterID(int id);
    }
}