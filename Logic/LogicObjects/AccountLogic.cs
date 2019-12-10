using Data;
using Data.Repositories;
using Interfaces.Contexts;
using Interfaces.Logic;
using Interfaces.Repositories;
using Models;
using System.Collections.Generic;

namespace Logic.LogicObjects
{
    public class AccountLogic: IAccountLogic
    {
        private readonly IAccountRepository AccountRepository;

        public AccountLogic(IAccountContext context)
        {
            AccountRepository = new AccountRepository(context);
        }
    }
}
