using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Pet;
using Domain.Repositories;
using Domain.ResultObject.Pet;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using Presenters;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {

        private IGetPetsInport GetPetsCase;
        private IGetPetsOutport GetPetsOutport;
        private ICreatePetInport CreatePetInport;
        private ICreatePetOutport CreatePetOutport;
        private IGetOnePetInport _getOnePetInport;
        private IGetOnePetOutport _getOnePetOutport;

        public PetController(IGetPetsInport getPetsCase, IGetPetsOutport getPetsOutport, ICreatePetInport createPetInport, ICreatePetOutport createPetOutport, IGetOnePetInport getOnePetInport, IGetOnePetOutport getOnePetOutport)
        {
            GetPetsCase = getPetsCase;
            GetPetsOutport = getPetsOutport;
            CreatePetInport = createPetInport;
            CreatePetOutport = createPetOutport;
            _getOnePetInport = getOnePetInport;
            _getOnePetOutport = getOnePetOutport;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePetEndpoint([FromForm] CreatePetDTO dto)
        {
            await CreatePetInport.Handle(dto);
            var result = ((IPresenter<OneOf<CreatePetResult, Error>>)CreatePetOutport).Content;

            return result.Match(
            createResult => Ok(createResult),
            error => error switch
            {
                Error { Reason: ErrorReason.FailDatabase } => Problem(
                  detail: error.Message,
                  statusCode: 503,
                  title: "Servicio no disponible"
                ),
                Error { Reason: ErrorReason.CreateFile } => Problem(
                    detail: error.Message,
                    statusCode: 409,
                    title: "Server Error"
                ),
                _ => Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                )
            }
            );
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] int skip, string province, string municipality)
        {
            await GetPetsCase.Handle(skip, province, municipality);

            var result = ((IPresenter<OneOf<GetAllPetResult, Error>>)GetPetsOutport).Content;

            return result.Match(
            getPetResult => Ok(getPetResult),
            error => error switch
            {
                Error { Reason: ErrorReason.FailDatabase } => Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server error"
                ),
                _ => Problem(
                   detail: error.Message,
                   statusCode: 500,
                   title: "Server Error"
               )
            });
        }

        [HttpGet("{userId}/{petId}")]
        public async Task<IActionResult> GetOnePetEndpoint(string userId, string petId)
        {
            await _getOnePetInport.Handle(userId, petId);

            var result = ((IPresenter<OneOf<GetOnePetResult, Error>>)_getOnePetOutport).Content;

            return result.Match(
           getOnePetResult => Ok(getOnePetResult),
           error => error switch
           {
               Error { Reason: ErrorReason.FailDatabase } => Problem(
                   detail: error.Message,
                   statusCode: 500,
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