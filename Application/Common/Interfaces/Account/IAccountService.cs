using Application.Common.Dto.Account.Request;
using Application.Common.Dto.Account.Response;
using Application.Common.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Account
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponseDto>> AuthenticateAsync(AuthenticationRequestDto request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequestDto request, string origin);
        Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequestDto model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequestDto model);
    }
}
