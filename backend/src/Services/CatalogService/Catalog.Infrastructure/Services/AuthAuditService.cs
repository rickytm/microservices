using Common.Audit;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Catalog.Infrastructure.Services;

public class AuditService : IAuditService
{
    private readonly IHttpContextAccessor _httpContextAccesor;

    public AuditService(IHttpContextAccessor httpContextAccesor)
    {
        _httpContextAccesor = httpContextAccesor;
    }

    public string GetSessionUser()
    {
        if (_httpContextAccesor.HttpContext != null)
        {
            var username = _httpContextAccesor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return username;
        }
        return null;

    }
}
