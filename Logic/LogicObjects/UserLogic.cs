using Data;
using Data.Repositories;
using Interfaces.Contexts;
using Interfaces.Logic;
using Interfaces.Repositories;
using Models;
using System.Collections.Generic;

namespace Logic.LogicObjects
{
    public class UserLogic: IUserLogic
    {
        private readonly IUserRepository UserRepository;

        public UserLogic(IUserContext context)
        {
            UserRepository = new UserRepository(context);
        }

        public void AuthenticateUser(string Username, string Password)
        {
            UserRepository.AuthenticateUser(Username, Password);
        }
    }
}
