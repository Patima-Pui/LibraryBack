// using System;
// using LibraryBack.Repositorys;

// namespace LibraryBack.Services
// {
//     public interface IUsersService
//     {
//         ResponseLoginModel LoginValidation(LoginModel requestLogin);
//     }
//     public class UsersService : IUsersService
//     {
//         private IUsersRepository _usersRepository;
//         public UsersService(IUsersRepository usersRepository)
//         {
//             usersRepository = _usersRepository
//         }

//         public ResponseLoginModel LoginValidation(LoginModel requestLogin)
//         {
//             ResponseLoginModel res = new ResponseLoginModel();
//             if (item.Username != "" && item.Password != "")
//             {
//                 var result = _userRepository.CheckLogin(request);

//                 if (result == "")
//                 {
//                     res.state = false;
//                     res.message = "Login fail";
//                     res.id = -1;
//                 }
//                 else
//                 {
//                     res.state = true;
//                     res.message = "Login success";
//                     res.id = Int32.Parse(result);
//                 }
//             }
//             else
//             {
//                 res.message = "Invalid Username or Password";
//                 throw new Exception("Invalid Username or Password");
//             }

//             return res;
//         }
//     }
// }