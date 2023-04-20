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

        public UserController(IRegisterUserInport registerInport, IRegisterUserOutport registerOutport, IConfiguration configuration)
        {
            RegisterInport = registerInport;
            RegisterOutport = registerOutport;
            Configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDTO dto)
        {
            await RegisterInport.Handle(dto,Configuration["Secret"]);

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

    }
}