using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entity;
using Domain;
using Domain.Repositories;
using Domain.ResultObject;
using Domain.Services.Token;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;
using System.Security.Claims;
using Domain.ModelObject.Token;
using Domain.DTO.User;
using Domain.ResultObject.User;

namespace UseCases.Case
{
    public class RegisterUser : IRegisterUserInport
    {

        private IRegisterUserOutport OutputPort;
        private ITokenManager TokenManager;
        private IUnitOfWork UnitOfWork;

        public RegisterUser(IRegisterUserOutport outputPort, ITokenManager tokenManager, IUnitOfWork unitOfWork)
        {
            OutputPort = outputPort;
            TokenManager = tokenManager;
            UnitOfWork = unitOfWork;
        }

        public async Task Handle(RegisterDTO dto, string secretKey)
        {
            var exist = await UnitOfWork.UserRepository.Exist(dto.Email);

            if(!exist)
            {
                var entity = dto.Adapt<User>();
                entity.Role = "User";
                await UnitOfWork.UserRepository.AddAsync(entity);
                await UnitOfWork.SaveAsync();
                var result = entity.Adapt<RegisterResult>();
                result.Id = entity.Id;
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Role, entity.Role),
                    new Claim(ClaimTypes.Email, entity.Email)
                };

                GenerateJwtMO model = new ()
                {
                    Claims = claims,
                    SecretKey = secretKey
                };

                result.Token = TokenManager.GenerateJwt(model);
                await OutputPort.Handle(result);

            }
            else
            {
                await OutputPort.Handle(new Error(ErrorReason.AlreadyExist, "Ya hay un usuario con ese email"));
            }
            
        }

    }
}