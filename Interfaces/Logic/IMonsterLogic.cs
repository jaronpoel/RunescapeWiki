﻿using Interfaces.Logic;
using Models;
using System.Collections.Generic;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IMonsterLogic : ILogic<Monster>
    {
        List<Monster> GetAllMonsters();
        Monster GetMonsterByID(int id);
    }
}