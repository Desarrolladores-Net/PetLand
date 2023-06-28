using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.User;
using Domain.ModelObject.Token;
using Domain.Repositories;
using Domain.ResultObject.User;
using Domain.Services.Token;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class Login : ILoginInport
    {
        private IUnitOfWork _unitOfWork;
        private ILoginOutport _outport;
        private ITokenManager _tokenService;


        public Login(IUnitOfWork unitOfWork, ILoginOutport outport, ITokenManager tokenService)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
            _tokenService = tokenService;
        }

        public async Task Handle(LoginDTO dto, string key)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.SignIn(dto.Value, dto.Password);

                if (user == null)
                {
                    await _outport.Handle(new Error(ErrorReason.Unauthorized, "Credenciales incorrectas"));
                }
                else
                {
                    var result = user.Adapt<LoginResult>();

                    List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                    GenerateJwtMO model = new()
                    {
                        Claims = claims,
                        SecretKey = key
                    };

                    result.Token = _tokenService.GenerateJwt(model);
                    await _outport.Handle(result);
                }

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}