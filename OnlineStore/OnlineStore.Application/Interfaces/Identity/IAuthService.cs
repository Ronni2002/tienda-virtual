using OnlineStore.Application.Models.Identity;

namespace OnlineStore.Application.Interfaces.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}