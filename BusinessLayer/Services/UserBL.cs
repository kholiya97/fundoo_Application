using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRl;

        public UserBL(IUserRL userRl)
        {
            this.userRl = userRl;
        }
        public Users AddUser(Users user)
        {
            this.userRl.AddUser(user);
            return user;
        }
        public string Login(string email, string password)
        {
            return this.userRl.Login(email, password);
        }


        public bool ForgotPassword(string email)
        {
            try
            {
                return this.userRl.ForgotPassword(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void ChangePassword(string email, string newPassword)
        {
            try
            {
                this.userRl.ChangePassword(email, newPassword);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

