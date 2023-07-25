using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.User;
using Domain.Repositories;
using Domain.ResultObject.User;
using Mapster;
using OneOf;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class GetAllUsers : IGetAllUsersInport
    {
        private IUnitOfWork _unitOfWork;
        private IGetAllUsersOutport _outport;

        public GetAllUsers(IUnitOfWork unitOfWork, IGetAllUsersOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(GetAllUserDTO dto)
        {
            try
            {
                var users = await _unitOfWork.UserRepository.GetAll(dto.Skip, dto.Take);

                var result = users.Adapt<List<GetAllUserResult>>();

                await _outport.Handle(result);

            }
            catch (System.Exception ex)
            {
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Error al conectar con la base de datos"));
            }
        }
    }
}