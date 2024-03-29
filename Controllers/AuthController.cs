﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using off_chain.DBContext;
using off_chain.Models;
using off_chain.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace off_chain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly MyDbContext _dbContext;

        public AuthController(IConfiguration configuration, IUserService userService, MyDbContext dbContext)
        {
            _configuration = configuration;
            _userService = userService;
            _dbContext = dbContext;
        }


        /// <summary>
        // Regis  for Cus
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        //[HttpPost("register")]
        //public async Task<ActionResult<User>> Register(UserDto request)
        //{
        //    CreatePasswordHash(request.PublicKey, out byte[] publicKeyHash, out byte[] publicKeySalt);

        //    user.PublicKey = request.PublicKey;
        //    user.PublicKeyHash = publicKeyHash;
        //    user.PublicKeySalt = publicKeySalt;

        //    return Ok(user);
        //}

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            CreatePasswordHash(request.PublicKey, out byte[] publicKeyHash, out byte[] publicKeySalt);

                user.PublicKey = request.PublicKey;
                user.PublicKeyHash = publicKeyHash;
                user.PublicKeySalt = publicKeySalt;
            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);
            //_dbContext.SaveChanges();
            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.PublicKey)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }






        private void CreatePasswordHash(string publicKey, out byte[] publicKeyHash, out byte[] publicKeySalt)
        {
            using (var hmac = new HMACSHA512())
            {
                publicKeySalt = hmac.Key;
                publicKeyHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(publicKey));
            }
        }

        private bool VerifyPasswordHash(string publicKey, byte[] publicKeyHash, byte[] publicKeySalt)
        {
            using (var hmac = new HMACSHA512(publicKeySalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(publicKey));
                return computedHash.SequenceEqual(publicKeyHash);
            }
        }
    }
}
