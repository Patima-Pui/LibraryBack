using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LibraryBack.Services;

namespace LibraryBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

         public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("AllUsers")]
        public UsersListModel GetUsersList()
        {
            UsersListModel result = _usersService.SelectAllUsersService();
            return result;
        }

        [HttpPost]
        [Route("Login")]
        public ResposeLoginModel Login([FromBody] LoginModle login)
        {
            ResposeLoginModel res = _usersService.CheckValidateLogin(login);
            return res;
        }

        [HttpPost]
        [Route("Register")]
        public ResponseModel Register([FromBody]UserModel register)
        {
            ResponseModel res = _usersService.CheckStateRegister(register);
            return res;
        }

    }
} 