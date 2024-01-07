using ConfitecWeb.Models;
using ConfitecWeb.Service.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        public UsersController(IUserInterface userIterface)
        {
            _userInterface = userIterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> GetUsers()
        {
            return Ok(await _userInterface.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<UserModel>>> GetUserById(int id)
        {
            ServiceResponse<UserModel> serviceResponse = await _userInterface.GetUserById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> CreateUser(UserModel newUser)
        {
            return Ok(await _userInterface.CreateUser(newUser));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> UpdateUser(UserModel editedEmploye)
        {
            ServiceResponse<List<UserModel>> serviceResponse = await _userInterface.UpdateUser(editedEmploye);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> DeleteUser(int id)
        {
            ServiceResponse<List<UserModel>> serviceResponse = await _userInterface.DeleteUser(id);

            return Ok(serviceResponse);


        }
    }
}
