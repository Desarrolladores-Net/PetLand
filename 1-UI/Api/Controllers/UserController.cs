using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO;
using Domain.DTO.User;
using Domain.ResultObject;
using Domain.ResultObject.User;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using Presenters;
using UseCases.InPorts;
using UseCases.OutPorts;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IRegisterUserInport RegisterInport;
        private IRegisterUserOutport RegisterOutport;
        private IConfiguration Configuration;
        private ILoginInport _loginInport;
        private ILoginOutport _loginOutport;
        private IGetAllUsersInport _getAllUsersInport;
        private IGetAllUsersOutport _getAllUsersOutport;

        public UserController(IRegisterUserInport registerInport, IRegisterUserOutport registerOutport, IConfiguration configuration, ILoginInport loginInport, ILoginOutport loginOutport, IGetAllUsersInport getAllUsersInport, IGetAllUsersOutport getAllUsersOutport)
        {
            RegisterInport = registerInport;
            RegisterOutport = registerOutport;
            Configuration = configuration;
            _loginInport = loginInport;
            _loginOutport = loginOutport;
            _getAllUsersInport = getAllUsersInport;
            _getAllUsersOutport = getAllUsersOutport;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDTO dto)
        {
            await RegisterInport.Handle(dto,Configuration["SecretKey"]);

            var result = ((IPresenter<OneOf<RegisterResult, Error>>)RegisterOutport).Content;

            return result.Match(
            registerResult => Ok(registerResult),
            error => error switch 
            {
                Error {Reason: ErrorReason.AlreadyExist} => Problem(
                    detail: error.Message,
                    statusCode: 409,
                    title: "Server error" 
                ),
                 _ => Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                )
            });

        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginEndpoint(LoginDTO dto)
        {
            await _loginInport.Handle(dto, Configuration["SecretKey"]);

            var result = ((IPresenter<OneOf<LoginResult, Error>>)_loginOutport).Content;

            return result.Match(
            data => Ok(data),
            error => error switch 
            {
                Error {Reason: ErrorReason.AlreadyExist} => Problem(
                    detail: error.Message,
                    statusCode: 409,
                    title: "Server error" 
                ),
                Error {Reason: ErrorReason.Unauthorized} => Problem(
                    detail: error.Message,
                    statusCode: 401,
                    title: "Server error" 
                ),
                 _ => Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                )
            });

        }

        [HttpGet("all")]
        public async Task<IActionResult> LoginEndpoint([FromQuery]GetAllUserDTO dto)
        {
            await _getAllUsersInport.Handle(dto);

            var result = ((IPresenter<OneOf<List<GetAllUserResult>, Error>>)_getAllUsersOutport).Content;

            return result.Match(
            data => Ok(data),
            error => error switch 
            {
                Error {Reason: ErrorReason.AlreadyExist} => Problem(
                    detail: error.Message,
                    statusCode: 409,
                    title: "Server error" 
                ),
                Error {Reason: ErrorReason.Unauthorized} => Problem(
                    detail: error.Message,
                    statusCode: 401,
                    title: "Server error" 
                ),
                 _ => Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                )
            });

        }

        

    }
}