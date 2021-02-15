// using System;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;

// namespace LibraryBack.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class UsersController : ControllerBase
//     {
//         private readonly IUsersService _usersService;

//         public UserController(IUserService userService)
//         {
//             _userService = userService;
//         }
//         [HttpPost]
//         [Route("Login")]
//         public ResponseLoginModel Login([formBody] LoginModel requestLogin)
//         {
//             ResponseLoginModel result = _userService.LoginValidation(LoginModel request);
//             return result;
//         }
//     }
// }