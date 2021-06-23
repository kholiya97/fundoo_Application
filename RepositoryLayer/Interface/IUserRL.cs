using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public interface IUserRL
    {
        Users AddUser(Users user);
        string Login(string email, string password);
        bool ForgotPassword(string email);
        void ChangePassword(string email, string newPassword);

    }
}
