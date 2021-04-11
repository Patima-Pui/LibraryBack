using System;
using LibraryBack.Repositories;

namespace LibraryBack.Services
{
    public interface IUsersService
    {
        UsersListModel SelectAllUsersService();
        ResposeLoginModel CheckValidateLogin(LoginModle login);
        ResponseModel CheckStateRegister(UserModel register);
    }
    
    public class UsersService : IUsersService
    {
        private IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
     
        public UsersListModel SelectAllUsersService()
        {
            UsersListModel result = _usersRepository.SelectAllUsers();
            return result;
        }

        public ResposeLoginModel CheckValidateLogin(LoginModle login)
        {
            ResposeLoginModel response = new ResposeLoginModel();
            int result = _usersRepository.SelectUserIdFromDB(login);
            if (result == -1)
            {
                response.state = false;
                response.message = "Login failed";
                response.userId = -1;
            }
            else
            {
                response.state = true;
                response.message = "Login successful";
                response.userId = result;
            }
            return response;
            
        }

        public ResponseModel CheckStateRegister(UserModel register) 
        {
            ResponseModel response = new ResponseModel();
            int result =_usersRepository.InsertUserDetails(register);
            if(result > 0)
            {
                response.state = true;
                response.message = "Register successful";
            }
            else
            {
                response.state = true;
                response.message = "Register failed";
            }
            return response;
        }
    }
}
