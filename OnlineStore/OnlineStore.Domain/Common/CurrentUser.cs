using Microsoft.AspNetCore.Http;
using OnlineStore.Domain.Constants;

namespace OnlineStore.Domain.Common;

public interface ICurrentUser
{
    string? GetCurrentUserId();
}

public class CurrentUser: ICurrentUser
{
    private readonly IHttpContextAccessor _accessor;
    
    public CurrentUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    public string? GetCurrentUserId()
    {
        return _accessor.HttpContext.User
            .Claims.FirstOrDefault(x => x.Type.Contains(CustomClaimTypes.Uid))?.Value;
    }
}