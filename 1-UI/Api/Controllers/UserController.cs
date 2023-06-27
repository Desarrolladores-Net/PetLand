using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO;
using Domain.DTO.User;
using Domain.Entity;
using Domain.ResultObject;
using Domain.ResultObject.User;
using Infra.Data;
using Microsoft.AspNetCore.Identity;
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
        private AppDbContext AppDbContext;

        public UserController(IRegisterUserInport registerInport, IRegisterUserOutport registerOutport, IConfiguration configuration, AppDbContext appDbContext)
        {
            RegisterInport = registerInport;
            RegisterOutport = registerOutport;
            Configuration = configuration;
            AppDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDTO dto)
        {
            await RegisterInport.Handle(dto, Configuration["SecretKey"]);

            var result = ((IPresenter<OneOf<RegisterResult, Error>>)RegisterOutport).Content;

            return result.Match(
            registerResult => Ok(registerResult),
            error => error switch
            {
                Error { Reason: ErrorReason.AlreadyExist } => Problem(
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

        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var user = AppDbContext.User.FirstOrDefault(u => u.Email == dto.Email);

            if (user == null)
            {
                return BadRequest("Correo electrónico o contraseña incorrectos.");
            }

            if (!VerifyPassword(user, dto.Password))
            {
                return BadRequest("Correo electrónico o contraseña incorrectos.");
            }



            return Ok("Inicio de sesión exitoso.");
        }

     

        private bool VerifyPassword(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.passwordHash, password);
            return result == PasswordVerificationResult.Success;
        }

    }
}