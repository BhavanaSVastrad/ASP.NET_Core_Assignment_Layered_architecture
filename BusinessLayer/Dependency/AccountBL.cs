using BusinessLayer.Dependency.IDependency;
using BusinessModel;
using DataaccessLayer.Account;
using DataaccessLayer.Dependency.IDependency;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dependency
{
    public class AccountBL :IAccountBL
    {
        private readonly IAccountDAL db;


        public AccountBL(IAccountDAL db)
        {
            this.db = db;


        }
       
        public LoginViewModel Login(LoginViewModel model)
        {
            return db.Login(model);
        }

        public void SignUp(SignUpViewModel model)
        {
            db.SignUp(model);
        }

    }
}
