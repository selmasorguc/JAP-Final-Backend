namespace MovieApp.Repository
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using MovieApp.Core.DTOs.UserDtos;
    using MovieApp.Core.Entities;
    using MovieApp.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Authentication;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;


    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SymmetricSecurityKey _key;

        private readonly SignInManager<AppUser> _signInManager;

        public AuthRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                                IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ServiceResponse<RegisterDto>> Login(LogInDto loginDto)
        {
            var serviceResponse = new ServiceResponse<RegisterDto>();

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == loginDto.Username);
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                throw new AuthenticationException("Username or password are not valid");

            serviceResponse.Data = new RegisterDto
            {
                Username = loginDto.Username,
                Token = await CreateToken(user)
            };


            return serviceResponse;
        }

        public async Task<ServiceResponse<RegisterDto>> Register(string username, string password)
        {
            var serviceResponse = new ServiceResponse<RegisterDto>();

            if (await UserExists(username))
                throw new ArgumentException("User exists");

            var user = new AppUser
            {
                UserName = username
            };

            IdentityResult result = await _userManager.CreateAsync(user, password);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            if (!result.Succeeded)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = result.Errors.ToString();
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = roleResult.Errors.ToString();
            }

            serviceResponse.Data = new RegisterDto
            {
                Username = username,
                Token = await CreateToken(user)
            };

            return serviceResponse;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username);
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
                throw new ArgumentException("User does not exist");

            return user;
        }
    }
}
