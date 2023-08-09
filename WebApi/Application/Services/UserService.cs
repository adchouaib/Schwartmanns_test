using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts;
using Application.DTOs;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private User? _user;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper, IUserRepository userRepository, UserManager<User> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task CreateUser(CreateUser user)
        {
            User newUser = _mapper.Map<User>(user);
            newUser.UserName = newUser.Name.Trim();
            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.ToString());
            }
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<Boolean> DeleteUser(DeleteUser deleteUser)
        {
            var user = await GetById(deleteUser.Id);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UpdatePassword(UpdatePassword updatePassword)
        {
            var user = await GetById(updatePassword.Id);
            var result = await _userManager.ChangePasswordAsync(user, updatePassword.currentPassword, updatePassword.newPassword);
            return result.Succeeded;
        }

        public async Task<JwtToken> Login(Login login)
        {
            var authorized = await ValidateUser(login);
            if (authorized)
            {
                string token = await CreateToken();
                return new JwtToken(token, _user.Name);
            }
            else
            {
                throw new UnauthorizedAccessException("Username or password not valid");
            }

        }

        private async Task<bool> ValidateUser(Login request)
        {
            _user = await _userManager.FindByEmailAsync(request.email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, request.password));

            if (!result)
                throw new UnauthorizedAccessException("User not valid");

            return result;
        }

        private async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }

        private static SigningCredentials GetSigningCredentials()
        {
            string secret = Environment.GetEnvironmentVariable("SECRET_KEY") ?? string.Empty;
            var key = Encoding.UTF8.GetBytes(secret);
            var securityKey = new SymmetricSecurityKey(key);

            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user!.UserName!)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(
            SigningCredentials signingCredentials,
            List<Claim> claims
        )
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var expirationMinutes = Convert.ToInt32(jwtSettings["expires"]);
            var expirationDateUtc = DateTime.UtcNow.AddMinutes(expirationMinutes);

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: expirationDateUtc,
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }


    }
}

