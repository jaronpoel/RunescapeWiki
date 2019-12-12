using Models;
using System;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext Context;

        public UserRepository(IUserContext context)
        {
            Context = context;
        }

        public void AuthenticatUser(string Username, string Password)
        {
            Context.AuthenticatUser(Username, Password);
        }

    }
}
