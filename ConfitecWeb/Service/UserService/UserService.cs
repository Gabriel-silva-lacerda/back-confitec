using ConfitecWeb.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication_Confitec.DataContext;

namespace ConfitecWeb.Service.UserService
{
    public class UserService : IUserInterface
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) 
        { 
            _context = context;
        }
        public async Task<ServiceResponse<List<UserModel>>> CreateUser(UserModel newUser)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();
            try
            {
                if(newUser == null) 
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Sucess = false;

                    return serviceResponse;
                }

                _context.Add(newUser);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserModel>>> DeleteUser(int id)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                UserModel user = _context.Users.FirstOrDefault(x => x.Id == id);

                if(user == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não encontrado!";
                    serviceResponse.Sucess = false;

                    return serviceResponse;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        

        public async Task<ServiceResponse<UserModel>> GetUserById(int id)
        {
            ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();


            try
            {
                UserModel user = _context.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Sucess = false;
                
                }

                serviceResponse.Data = user;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserModel>>> GetUsers()
        {
           ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                serviceResponse.Data = _context.Users.ToList();

                if(serviceResponse.Data.Count == 0 ) 
                {
                    serviceResponse.Message = "Nenhum dado encontrado";
                }
            }catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserModel>>> UpdateUser(UserModel editedEmploye)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                UserModel user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == editedEmploye.Id);

                if(user == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não encotrado!";
                    serviceResponse.Sucess = false;

                }


                _context.Users.Update(editedEmploye);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Users.ToList();

            } catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;

            }


            return serviceResponse;
        }
    }
}
