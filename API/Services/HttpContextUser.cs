using Application.Common.Interfaces.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace API.Services
{
    public class HttpContextUser : IHttpContextUser
    {
        public HttpContextUser(IHttpContextAccessor httpContextAccessor)
        {
            Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        }

        public string Id { get; }
    }
}
