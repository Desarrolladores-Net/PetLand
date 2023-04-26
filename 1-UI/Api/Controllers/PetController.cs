using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Pet;
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
        private ICreatePetInport CreatePetInport;
        private ICreatePetOutport CreatePetOutport;

        public PetController(ICreatePetInport createPetInport, ICreatePetOutport createPetOutport)
        {
            CreatePetInport = createPetInport;
            CreatePetOutport = createPetOutport;
        }

        [HttpPost]
        public async Task<IActionResult> CeatePetEndpoint([FromForm] CreatePetDTO dto)
        {
            await CreatePetInport.Handle(dto);
            var result = ((IPresenter<OneOf<CreatePetResult, Error>>)CreatePetOutport).Content;

            return result.Match(
            createResult => Ok(createResult),
            error => Problem(
                   detail: error.Message,
                   statusCode: 500,
                   title: "Server Error"
               )
            );
        }



    }
}