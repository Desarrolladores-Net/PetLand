using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
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

        public PetController(IGetPetsInport getPetsCase, IGetPetsOutport getPetsOutport)
        {
            GetPetsCase = getPetsCase;
            GetPetsOutport = getPetsOutport;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery]int skip)
        {
            await GetPetsCase.Handle(skip);
            
            var result = ((IPresenter<OneOf<List<GetPetResult>, Error>>)GetPetsOutport).Content;

            return result.Match(
            getPetResult => Ok(getPetResult),
            error => error switch 
            {
                Error {Reason: ErrorReason.FailDatabase} => Problem(
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