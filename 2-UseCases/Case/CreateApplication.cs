using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Application;
using Domain.Entity;
using Domain.Repositories;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class CreateApplication : ICreateApplicationInport
    {
        private IUnitOfWork _unitOfWork;
        private ICreateApplicationOutport _outport;

        public CreateApplication(IUnitOfWork unitOfWork, ICreateApplicationOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(CreateApplicationDTO dto)
        {
            try
            {

                var entity = new Application()
                {
                    Id = Guid.NewGuid().ToString(),
                    PetId = dto.PetId,
                    UserId = dto.UserId,
                    Date = DateTime.UtcNow
                };

                entity.UserResponse = dto.UserResponse.Select( x => new UserResponse{
                    ApplicationId = entity.Id,
                    Id = Guid.NewGuid().ToString(),
                    Question = x.Question,
                    Response = x.Response
                }).ToList();
                
                await _unitOfWork.ApplicationRepository.AddAsync(entity);
                await _unitOfWork.SaveAsync();

                await _outport.Handle(entity);

            }
            catch (System.Exception ex)
            {

                await _outport.Handle(new Error(ErrorReason.FailDatabase, "No se pudo conectar con la base de datos"));
            }


        }
    }
}