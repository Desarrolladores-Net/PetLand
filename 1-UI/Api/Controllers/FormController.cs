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

        public FormController(ICreateFormInport createFormInport, ICreateFormOutport creFormOutport)
        {
            _createFormInport = createFormInport;
            _createFormOutport = creFormOutport;
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



    }
}