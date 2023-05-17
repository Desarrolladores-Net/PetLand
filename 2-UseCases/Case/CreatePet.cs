using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Pet;
using Domain.Entity;
using Domain.Repositories;
using Domain.ResultObject.Pet;
using Domain.Services.Files;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class CreatePet : ICreatePetInport
    {

        private IUnitOfWork _unitOfWork;
        private ICreatePetOutport Outport;
        private IFileManager _fileManager;

        public CreatePet(IUnitOfWork unitOfWork, ICreatePetOutport outport, IFileManager fileManager)
        {
            _unitOfWork = unitOfWork;
            Outport = outport;
            _fileManager = fileManager;
        }

        public async Task Handle(CreatePetDTO dto)
        {
            try
            {
                var entity = dto.Adapt<Pet>();
                var path = await _fileManager.SavePetPicture(dto.Photo, entity.Id);

                entity.PhotoPath = path;
                await _unitOfWork.PetRepository.AddAsync(entity);

                await _unitOfWork.SaveAsync();



                var result = new CreatePetResult()
                {
                    Success = true
                };

                await Outport.Handle(result);


            }
            catch (System.Exception ex)
            {

                await Outport.Handle(new Error(ErrorReason.SaveEntity, ex.Message));
            }
        }
    }
}