using BCrypt.Net;
using Bedienungshilfe.Entity;
using Bedienungshilfe.Repository;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedienungshilfe
{
    class UserAccess
    {
        private UserContext userContext;

        public UserAccess()
        {
            this.userContext = new UserContext();
        }

        public User LogIn(string username, string password)
        {
            User user = this.userContext.FindByUsername(username);

            if (user == null)
            {
                throw new Exception("Username is not correct.");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.password)) {
                throw new BcryptAuthenticationException("Password is not correct.");
            }

            return user;
        }

        public void Logout(User user)
        {

        }
    }
}
