using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Pet;
using Domain.Repositories;
using Domain.Services.ExternalServices;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class CreatePet : ICreatePetInport
    {
        private IDropboxManager _dbx;
        private IUnitOfWork _unitOfWork;
        private ICreatePetOutport Outport;

        public CreatePet(IDropboxManager dbx, IUnitOfWork unitOfWork, ICreatePetOutport outport)
        {
            _dbx = dbx;
            _unitOfWork = unitOfWork;
            Outport = outport;
        }

        public async Task Handle(CreatePetDTO dto)
        {
            try
            {
                var response = await _dbx.UploadPetPhoto(dto.Photo.OpenReadStream(), 1, Path.GetExtension(dto.Photo.FileName));

                

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}