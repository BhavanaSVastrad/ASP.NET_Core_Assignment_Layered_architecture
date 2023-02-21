using BusinessModel;
using DataaccessLayer.Account;

using System;
using System.Collections.Generic;
using System.Text;

namespace DataaccessLayer.Dependency.IDependency
{
    public interface IAccountDAL
    {
        
        LoginViewModel Login(LoginViewModel model);

        void SignUp(SignUpViewModel model);
    }
}
