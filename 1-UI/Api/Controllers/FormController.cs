using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Form;
using Domain.ResultObject.Form;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using Presenters;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private ICreateFormInport _createFormInport;
        private ICreateFormOutport _createFormOutport;
        private IGetFormsInport _getFormsInport;
        private IGetFormsOutport _getFormsOutport;

        public FormController(ICreateFormInport createFormInport, ICreateFormOutport createFormOutport, IGetFormsInport getFormsInport, IGetFormsOutport getFormsOutport)
        {
            _createFormInport = createFormInport;
            _createFormOutport = createFormOutport;
            _getFormsInport = getFormsInport;
            _getFormsOutport = getFormsOutport;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFormEndpoint(CreateFormDTO dto)
        {
            await _createFormInport.Handle(dto);

            var result = ((IPresenter<OneOf<CreateFormResult, Error>>)_createFormOutport).Content;

            return result.Match(
                createFormResult => Ok(createFormResult),
                error => error switch
                {
                    Error { Reason: ErrorReason.SaveEntity } => Problem(
                        detail: error.Message,
                        statusCode: 500,
                        title: "Server error"
                    ),
                    _ => Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                )

                }
            );

        }

        [HttpGet]
        public async Task<IActionResult> GetFormsEndpoint()
        {
            await _getFormsInport.Handle();

            var result =  ((IPresenter<OneOf<GetAllFormsResult, Error>>)_getFormsOutport).Content;

            return result.Match(
                getFormsResult => Ok(getFormsResult),
                error => error switch
                {
                    Error {Reason: ErrorReason.FailDatabase } => Problem(
                        detail: error.Message,
                        statusCode: 500,
                        title: "Server error"
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