using DataaccessLayer.Account;
using DataaccessLayer.Dependency.IDependency;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel;

namespace DataaccessLayer.Dependency
{
    public class AccountDAL:IAccountDAL
    {
        private readonly ProductDbContext _context;



        public AccountDAL(ProductDbContext context)
        {
            _context = context;
        }

       

        public LoginViewModel Login(LoginViewModel model)
        {

            //User user = new User();
            //user.Email = model.Email;

            _context.Users.Where(e => e.Email == model.Email).SingleOrDefault();

             return model;
        }

       
        public void SignUp(SignUpViewModel model)
        {
            var data = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Mobile = (long)model.Mobile,
                Password = model.Password

            };
            _context.Add(data);
            _context.SaveChanges();
        }
    }
}
