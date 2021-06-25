using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FundooApplication.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBl;
        public UserController(IUserBL userBl)
        {
            this.userBl = userBl;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult AddUser(Users user)
        {
            try
            {
                this.userBl.AddUser(user);
                return this.Ok(new { success = true, message = "Registration Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult LoginUser(EmailModel emailModel)
        {
            var token = this.userBl.Login(emailModel.Email, emailModel.Password);
            if (token == null)
                return Unauthorized();
            return this.Ok(new { token = token, success = true, message = "Token Generated Successfull" });
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public ActionResult ForgotPassword(Users user)
        {
            try
            {
                bool isExist = this.userBl.ForgotPassword(user.Email);
                if (isExist) return Ok(new { success = true, message = $"Reset Link sent to {user.Email}" });
                else return BadRequest(new { success = false, message = $"No user Exist with {user.Email}" });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
      [AllowAnonymous]
        [HttpPut("reset-password")]
        public ActionResult ResetPassword(UserNewPassword user)
        {
            try
            {
                if (user.NewPassword != user.ConfirmPassword)
                {
                    return Ok(new { success = false, message = "New Password and Confirm Password are not equal." });
                }
                var UserEmailObject = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
                this.userBl.ChangePassword(UserEmailObject.Value, user.NewPassword);
                //return Ok($"Updated Email: {UserEmailObject.Value} NewPassword: {user.Password}");
                return Ok(new { success = true, message = "Password Changed Sucessfully", email = $"{UserEmailObject.Value}" });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

