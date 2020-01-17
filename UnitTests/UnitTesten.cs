using Interfaces.Contexts;
using Logic.LogicObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Logic;
using Exceptions.User;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        private readonly IUserLogic UserLogicTest;
        private readonly IGameAccountLogic GameAccountTest;
        private readonly ITipLogic TipTest;
        private readonly IMonsterLogic MonsterTest;

        #region Positive

        #region User

        [TestMethod]
        public void InsertUser()
        {
            UserLogicTest.InsertUser(new User()
            {
                Username = "jaron",
                Email = "jaron@gmail.com",
                Password = "123"
            });

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateUser()
        {
            UserLogicTest.InsertUser(new User()
            {
                Username = "jaron",
                Email = "jaron@gmail.com",
                Password = "123"
            });

            UserLogicTest.UpdateUser(new User()
            {
                Username = "aap",
                Email = "jaron@gmail.com",
                Password = "123"
            });

            Assert.IsTrue(true);
        }
        #endregion

        #region Monster

        [TestMethod]
        public void GetAllMonsters()
        {
            MonsterTest.GetAllMonsters();

            Assert.IsTrue(true);
        }

        public void GetMonsterByID()
        {
            int id = 1;
            MonsterTest.GetMonsterByID(id);

            Assert.IsTrue(true);
        }


        #endregion

        #region Tip

        public void GetTipByMonsterID()
        {
            int id = 1;
            TipTest.GetTipByMonsterID(id);

            Assert.IsTrue(true);
        }
        #endregion

        #region GameAccount

        public void GetAccountByID()
        {
            int id = 1;
            GameAccountTest.GetAccountByID(id);

            Assert.IsTrue(true);
        }
        #endregion

        #endregion

        #region Negative

        #region AuthenticatUser

        [TestMethod]
        public void AuthenticatUserFail()
        {
            bool result;
            try
            {
                UserLogicTest.AuthenticatUser("", "123");
                result = true;
            }
            catch(AuthenticationFailedException ex)
            {
                result = false;
            }
            
            Assert.IsFalse(result);
        }

        #endregion

        #region Sign Up
        [TestMethod]
        public void SignUp()
        {
            bool result = false;

            UserLogicTest.InsertUser(new User()
            {
                Username = "jaron",
                Email = "jaron@gmail.com",
                Password = "123"
            });

            try
            {
                UserLogicTest.InsertUser(new User()
                {
                    Username = "Noot",
                    Email = "jaron@gmail.com",
                    Password = "123"
                });
                result = true;
            }
            catch (RegistrationFailedException)
            {
                result = false;
            }

            Assert.IsFalse(result);
        }
        #endregion

        #endregion

        #region Integration

        [TestMethod]
        public void SignUpAndAuthenticatUser_Succes()
        {
            string username = "Kereltje";
            bool result = false;

            UserLogicTest.InsertUser(new User()
            {
                Username = username,
                Email = "Jaron@gmail.com",
                Password = "123"
            });

            try
            {
                UserLogicTest.AuthenticatUser(username, "123");
                result = true;
            }
            catch(AuthenticationFailedException ex)
            {
                result = false;
            }
            

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SignUpAndAuthenticatUser_FailedPassword()
        {
            string username = "Kereltje";
            bool result = false;

            UserLogicTest.InsertUser(new User()
            {
                Username = username,
                Email = "Jaron@gmail.com",
                Password = "123"
            });

            try
            {
                UserLogicTest.AuthenticatUser(username, "456");
                result = true;
            }
            catch (AuthenticationFailedException ex)
            {
                result = false;
            }


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SignUpAndAuthenticatUser_FailedUser()
        {
            string username = "Kereltje";
            bool result = false;

            UserLogicTest.InsertUser(new User()
            {
                Username = username,
                Email = "Jaron@gmail.com",
                Password = "123"
            });

            try
            {
                UserLogicTest.AuthenticatUser("Mannetje", "123");
                result = true;
            }
            catch (AuthenticationFailedException ex)
            {
                result = false;
            }


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SignUpAndUpdate_Succes()
        {
            bool result = false;

            UserLogicTest.InsertUser(new User()
            {
                Username = "Poel",
                Email = "Jaron@gmail.com",
                Password = "123"
            });

            UserLogicTest.UpdateUser(new User()
            {
                Username = "Vlerk",
                Email = "Jaron@gmail.com",
                Password = "123"
            });

            try
            {
                UserLogicTest.AuthenticatUser("Vlerk", "123");
                result = true;
            }
            catch (AuthenticationFailedException ex)
            {
                result = false;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SignUpAndUpdate_Failed()
        {
            bool result = false;

            UserLogicTest.InsertUser(new User()
            {
                Username = "Poel",
                Email = "Jaron@gmail.com",
                Password = "123"
            });

            UserLogicTest.UpdateUser(new User()
            {
                Username = "Vlerk",
                Email = "Jaron@gmail.com",
                Password = "123"
            });

            try
            {
                UserLogicTest.AuthenticatUser("Poel", "123");
                result = true;
            }
            catch (AuthenticationFailedException ex)
            {
                result = false;
            }

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateGameAccountStats()
        {
            UserLogicTest.InsertUser(new User()
            {
                Username = "Mies",
                Email = "Jaron@gmail.com",
                Password = "123"
            });

            var user = UserLogicTest.AuthenticatUser("Mies", "123");

            var gameaccount = GameAccountTest.GetAccountByID(user.Id);
            int oldslayer = gameaccount.Slayer;

            GameAccountTest.UpdateStats(new GameAccount()
            {
                Id = gameaccount.Id,
                Name = gameaccount.Name,
                Kind = gameaccount.Kind,
                Attack = gameaccount.Attack,
                Defence = gameaccount.Defence,
                Strength = gameaccount.Strength,
                Slayer = gameaccount.Slayer + 1
            });

            var gameaccountNew = GameAccountTest.GetAccountByID(user.Id);

            Assert.AreNotEqual(oldslayer, gameaccountNew.Slayer);
        }
        #endregion
    }
}