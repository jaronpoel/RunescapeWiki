﻿using Models;


namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        void AuthenticatUser(string Username, string Password);
    }
}