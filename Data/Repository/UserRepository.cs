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

        public User UpdateUser(User user)
        {
            return Context.UpdateUser(user);
        }

        public User GetUserByID(int id)
        {
            return Context.GetUserByID(id);
        }
        public void InsertUser(User user)
        {
            Context.InsertUser(user);
        }
    }
}
