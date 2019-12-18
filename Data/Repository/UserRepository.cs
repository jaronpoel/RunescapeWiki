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

        public User AuthenticatUser(string Username, string Password)
        {
            return Context.AuthenticatUser(Username, Password);
        }
    }
}
