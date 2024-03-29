using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Application;
using Domain.Entity;
using Domain.Repositories;
using Domain.ResultObject.Application;
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
        private IGetApplicationsInport _getApplicationsInport;
        private IGetApplicationsOutport _getApplicationsOutport;
        private IGetOneApplicationInport _getOneApplicationInport;
        private IOneAppOutport _getOneApplicationOutport;
        private ISetApplicationStateInport _setApplicationInport;
        private ISetApplicationStateOutport _setApplicationOutport;

        public AdoptionController(IUnitOfWork unitOfWork, ICreateApplicationInport createApplicationInport, ICreateApplicationOutport createApplicationOutport, IGetApplicationsInport getApplicationsInport, IGetApplicationsOutport getApplicationsOutport, IGetOneApplicationInport getOneApplicationInport, IOneAppOutport getOneApplicationOutport, ISetApplicationStateInport setApplicationInport, ISetApplicationStateOutport setApplicationOutport)
        {
            _unitOfWork = unitOfWork;
            _createApplicationInport = createApplicationInport;
            _createApplicationOutport = createApplicationOutport;
            _getApplicationsInport = getApplicationsInport;
            _getApplicationsOutport = getApplicationsOutport;
            _getOneApplicationInport = getOneApplicationInport;
            _getOneApplicationOutport = getOneApplicationOutport;
            _setApplicationInport = setApplicationInport;
            _setApplicationOutport = setApplicationOutport;
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

        [HttpGet("{skip}/{state}")]
        public async Task<IActionResult> GetApplicationsEndpoint(int skip, ApplicationState state)
        {
            await _getApplicationsInport.Handle(skip, state);

            var result = ((IPresenter<OneOf<GetApplicationsResult, Error>>)_getApplicationsOutport).Content;

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

        [HttpGet("{applicationId}")]
        public async Task<IActionResult> GetOneApplicationsEndpoint(string applicationId)
        {
            await _getOneApplicationInport.Handle(applicationId);

            var result = ((IPresenter<OneOf<Application, Error>>)_getOneApplicationOutport).Content;

            return result.Match(
                getOneApp =>
                {
                    return Ok(getOneApp);
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

        [HttpPut]
        public async Task<IActionResult> SetApplicationStateEndpoint(SetApplicationStateDTO dto)
        {
            await _setApplicationInport.Handle(dto);

            var result = ((IPresenter<OneOf<Application, Error>>)_setApplicationOutport).Content;

            return result.Match(
                data =>
                {
                    return Ok(data);
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