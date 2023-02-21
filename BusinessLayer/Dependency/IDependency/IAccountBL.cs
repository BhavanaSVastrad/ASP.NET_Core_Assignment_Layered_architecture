using BusinessModel;
using DataaccessLayer.Account;

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Dependency.IDependency
{
    public interface IAccountBL
    {
       

        LoginViewModel Login(LoginViewModel model);

        void SignUp(SignUpViewModel model);
    }
}
