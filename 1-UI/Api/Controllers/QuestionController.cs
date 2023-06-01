using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Question;
using Microsoft.AspNetCore.Mvc;
using Presenters;
using UseCases.InPorts;
using UseCases.OutPorts;
using OneOf;
using Domain.Entity;
using Domain;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private ICreateQuestionInport _createQuestionInport;
        private ICreateQuestionOutport _createQuestionOutport;

        public QuestionController(ICreateQuestionInport createQuestionInport, ICreateQuestionOutport createQuestionOutport)
        {
            _createQuestionInport = createQuestionInport;
            _createQuestionOutport = createQuestionOutport;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestionEndpoint(CreateQuestionDTO dto)
        {
            await _createQuestionInport.Handle(dto);

            var result = ((IPresenter<OneOf<Question, Error>>)_createQuestionOutport).Content;


            return result.Match(
                createQuestionResult => Ok(createQuestionResult),
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