using E_portal_API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace E_portal_API.Services
{
    public class UserService
    {
        private readonly string _secretKey;

        //public UserService(string secretKey)
        //{
        //    _secretKey = secretKey;
        //}
        //public string GenerateToken(LoginResponseModel req)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_secretKey);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //        new Claim(ClaimTypes.Name, req.Name),
        //        new Claim(ClaimTypes.Email, req.Email),
        //    }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
        //                                                    SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
        public LoginResponseModel Authenticate(LoginRequestModel req)
        {
            LoginResponseModel response = null;
            //Get user credentials from DB
            using (UserEntities db = new UserEntities())
            {
                    var user = db.Users.Where(x => x.Email == req.Email&& x.Password==req.Password).FirstOrDefault();
                    if (user != null)
                    {
                    response = new LoginResponseModel();
                    response.Name = user.Name;
                    response.Email = user.Email;
                    response.Id = user.Id;
                   // var token = GenerateToken(response);
                    //response.Token = token;
                    }            
            }

            return  response;
        }

        public DashboardResponseModel GetDashboard(int id)
        {
            DashboardResponseModel response = null;
            // using var connection = new SqlConnection(_connectionString);
            using (UserEntities db = new UserEntities())
            {
                var user = db.Users.Where(x => x.Id==id).FirstOrDefault();
                if (user != null)
                {
                    response = new DashboardResponseModel();
                    response.Name = user.Name;
                    response.Email = user.Email;
                    response.Id = user.Id;
                    response.Mobile = user.Mobile;
                    response.UserType = user.UserType;
                 
                }

            }

            return response;
        }
    }
}