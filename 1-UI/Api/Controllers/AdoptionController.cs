using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Application;
using Domain.Entity;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using Presenters;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdoptionController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private ICreateApplicationInport _createApplicationInport;
        private ICreateApplicationOutport _createApplicationOutport;

        public AdoptionController(IUnitOfWork unitOfWork, ICreateApplicationInport createApplicationInport, ICreateApplicationOutport createApplicationOutport)
        {
            _unitOfWork = unitOfWork;
            _createApplicationInport = createApplicationInport;
            _createApplicationOutport = createApplicationOutport;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicationEndpoint(CreateApplicationDTO dto)
        {
            await _createApplicationInport.Handle(dto);

            var result = ((IPresenter<OneOf<Application, Error>>)_createApplicationOutport).Content;

            return result.Match(
                createApplication =>
                {
                    return Ok(createApplication);
                },
                error => error switch
                {
                    Error { Reason: ErrorReason.FailDatabase } => Problem(
                       detail: error.Message,
                       statusCode: 500,
                       title: "Server Error"
                   ),
                   Error { Reason: ErrorReason.AlreadyExist } => Problem(
                       detail: error.Message,
                       statusCode: 409,
                       title: "Server Error"
                   ),
                    _ => Problem(
                        detail: error.Message,
                        statusCode: 500,
                        title: "Server error"
                    )
                }
            );

        }

    }
}