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

        public User AuthenticatUser(string Username, string Password)
        {
            return UserRepository.AuthenticatUser(Username, Password);
        }

        public User UpdateUser(User user)
        {
            return UserRepository.UpdateUser(user);
        }

        public User GetUserByID(int id)
        {
            return UserRepository.GetUserByID(id);
        }
    }
}
