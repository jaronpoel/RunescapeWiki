using Data;
using Data.Repositories;
using Interfaces.Contexts;
using Interfaces.Logic;
using Interfaces.Repositories;
using Models;
using System.Collections.Generic;

namespace Logic.LogicObjects
{
    public class GameAccountLogic: IGameAccountLogic
    {
        private readonly IGameAccountRepository AccountRepository;

        public GameAccountLogic(IGameAccountContext context)
        {
            AccountRepository = new GameAccountRepository(context);
        }

        public GameAccount GetAccountByID(int id)
        {
            return AccountRepository.GetAccountByID(id);
        }
    }
}
