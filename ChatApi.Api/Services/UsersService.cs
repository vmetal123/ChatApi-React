using ChatApi.Api.Common;
using ChatApi.Api.Contracts.v1.Requests;
using ChatApi.Api.Contracts.v1.Responses;
using ChatApi.Api.Identity;
using ChatApi.Api.Identity.ViewModels;
using ChatApi.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Services
{
    public class UsersService: IUsersService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<UsersService> _logger;
        private readonly JwtSettings _jwtSettings;

        public UsersService(UserManager<AppUser> userManager, ILogger<UsersService> logger, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _logger = logger;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<RegisterUserResponse> Register(RegisterUserRequest request)
        {
            try
            {
                var appUser = new AppUser { Email = request.Email, UserName = request.Email };

                var result = await _userManager.CreateAsync(appUser, request.Password);
            
                if(!result.Succeeded)
                {
                    _logger.LogInformation($"No se pudo registrar al usuario: {request.Email}, errores generados: {string.Join(", ",result.Errors.Select(x=>x.Description).ToArray())}");
                    return new RegisterUserResponse { Errors = result.Errors.Select(x=>x.Description).ToList(), Success = false };
                }

                return new RegisterUserResponse { Success = true };
            }
            catch (Exception ex)
            {
                return new RegisterUserResponse { Success = false, Errors = new List<string> { ex.Message.ToString() } };
            }
        }

        public async Task<LoginUserResponse> Login(LoginUserRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user is null) return new LoginUserResponse { Success = false, Errors = new List<string> { "Error on credentials." } };

                var result = await _userManager.CheckPasswordAsync(user, request.Password);

                if(!result) return new LoginUserResponse { Success = false, Errors = new List<string> { "Error on credentials." } };

                var token = GenerateToken(user);

                return new LoginUserResponse { Success = true, Token = token, Email = user.Email };
            }
            catch (Exception ex)
            {

                return new LoginUserResponse { Success = false, Errors = new List<string> { ex.Message.ToString() } };
            }
        }

        public async Task<ListUsersResponse> Users()
        {
            var users = await _userManager.Users.Select(x => new UserDto { Email = x.Email }).ToListAsync();

            return new ListUsersResponse { Success = true, Users = users };

        }

        private string GenerateToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("Id", user.Id.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
