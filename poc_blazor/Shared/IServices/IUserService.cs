using poc_blazor.Shared.DTO;

namespace poc_blazor.Shared.IServices
{
    public interface IUserService
    {
        Task<bool> LogIn(UserDTO.Login model);
        Task<bool> Register(UserDTO.Register model);
    }
}
