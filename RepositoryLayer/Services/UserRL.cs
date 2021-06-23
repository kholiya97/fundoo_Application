﻿using CommonLayer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Experimental.System.Messaging;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {

        private UserContext _userDbContext;
        public UserRL(UserContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public Users AddUser(Users newuser)
        {
            _userDbContext.Users.Add(newuser);
            _userDbContext.SaveChanges();
            return newuser;
        }
        public string Login(string email, string password)
        {
            var result = _userDbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (result == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("HelloThisTokenIsGeneretedByMe");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ForgotPassword(string email)
        {
            try
            {
                var result = _userDbContext.Users.FirstOrDefault(u => u.Email == email);
                if (result == null)
                {
                    return false;
                }
               // MessageQueue queue;

                //ADD MESSAGE TO QUEUE
                //if (MessageQueue.Exists(@".\Private$\FundooQueue"))
                //{
                //    queue = new MessageQueue(@".\Private$\FundooQueue");
                //}
                //else
                //{
                //    queue = MessageQueue.Create(@".\Private$\FundooQueue");
                //}

                //Message MyMessage = new Message();
                //MyMessage.Formatter = new BinaryMessageFormatter();
                //MyMessage.Body = email;
                //MyMessage.Label = "Forget Password Email";
                //queue.Send(MyMessage);
                //Message msg = queue.Receive();
                //msg.Formatter = new BinaryMessageFormatter();
                EmailService.SendEmail(email, GenerateToken(email));
                //queue.ReceiveCompleted += new ReceiveCompletedEventHandler(msmqQueue_ReceiveCompleted);

                //queue.BeginReceive();
                //queue.Close();
                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        private void msmqQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                MessageQueue queue = (MessageQueue)sender;
                Message msg = queue.EndReceive(e.AsyncResult);
                EmailService.SendEmail(e.Message.ToString(), GenerateToken(e.Message.ToString()));
                queue.BeginReceive();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }
        public string GenerateToken(string email)
        {
            if (email == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email",email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public void ChangePassword(string email, string newPassword)
        {
            try
            {
                var result = _userDbContext.Users.FirstOrDefault(u => u.Email == email);
                if (result != null)
                {
                    string encryptedPassword = StringCipher.Encrypt(newPassword);
                    result.Password = encryptedPassword;
                    _userDbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

