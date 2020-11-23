using Api.Extensions;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Email => _httpContextAccessor.HttpContext?.User?.GetEmailFromClaimsPrincipal();

        public string DisplayName => _httpContextAccessor.HttpContext?.User?.GetUserNameFromClaimsPrincipal();
    }
}
