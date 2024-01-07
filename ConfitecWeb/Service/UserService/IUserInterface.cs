using ConfitecWeb.Models;

namespace ConfitecWeb.Service.UserService
{
    public interface IUserInterface
    {
        Task<ServiceResponse<List<UserModel>>> GetUsers();

        Task<ServiceResponse<List<UserModel>>> CreateUser(UserModel newUser);

        Task<ServiceResponse<UserModel>> GetUserById(int id);

        Task<ServiceResponse<List<UserModel>>> UpdateUser(UserModel editedEmploye);

        Task<ServiceResponse<List<UserModel>>> DeleteUser(int id);
    }
}
