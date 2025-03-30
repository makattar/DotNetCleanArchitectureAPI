using Application.Common.Dto.Account.Request;
using Application.Common.Dto.Account.Response;
using Application.Common.Dto.Common;
using Application.Common.Interfaces.Account;
using Application.Common.Interfaces.Email;
using Domain.Settings;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly JWTSettings _jwtSettings;
        public AccountService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JWTSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public Task<Response<AuthenticationResponseDto>> AuthenticateAsync(AuthenticationRequestDto request, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> ConfirmEmailAsync(string userId, string code)
        {
            throw new NotImplementedException();
        }

        public Task ForgotPassword(ForgotPasswordRequestDto model, string origin)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> RegisterAsync(RegisterRequestDto request, string origin)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> ResetPassword(ResetPasswordRequestDto model)
        {
            throw new NotImplementedException();
        }
    }
}
