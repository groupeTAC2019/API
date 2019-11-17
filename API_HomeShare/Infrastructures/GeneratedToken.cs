using API_HomeShare.Infrastructures.TokenManager;
using API_HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace API_HomeShare.Infrastructures
{
    public static class GeneratedToken
    {
        internal static JWTContainerModel GetJWTContainerModel(string name, string email)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email)
                }
            };
        }


    }
}