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
using Domain.ResultObject.Question;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private ICreateQuestionInport _createQuestionInport;
        private ICreateQuestionOutport _createQuestionOutport;
        private IGetQuestionInport _getQuestionInport;
        private IGetQuestionOutport _getQuestionOutport;
        private IDeleteQuestionInport _deleteQuestionInport;
        private IDeleteQuestionOutport _deleteQuestionOutport;

        public QuestionController(ICreateQuestionInport createQuestionInport, ICreateQuestionOutport createQuestionOutport, IGetQuestionInport getQuestionInport, IGetQuestionOutport getQuestionOutport, IDeleteQuestionInport deleteQuestionInport, IDeleteQuestionOutport deleteQuestionOutport)
        {
            _createQuestionInport = createQuestionInport;
            _createQuestionOutport = createQuestionOutport;
            _getQuestionInport = getQuestionInport;
            _getQuestionOutport = getQuestionOutport;
            _deleteQuestionInport = deleteQuestionInport;
            _deleteQuestionOutport = deleteQuestionOutport;
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

        [HttpGet("{formId}")]
        public async Task<IActionResult> GetQuestionsEndpoint(string formId)
        {
            await _getQuestionInport.Handle(formId);

            var result = ((IPresenter<OneOf<List<GetQuestionResult>, Error>>)_getQuestionOutport).Content;


            return result.Match(
                getQuestionResult => Ok(getQuestionResult),
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

        [HttpDelete("{questionId}")]
        public async Task<IActionResult> Handle(string questionId)
        {
            await _deleteQuestionInport.Handle(questionId);

            var result = ((IPresenter<OneOf<GetQuestionResult, Error>>)_deleteQuestionOutport).Content;


            return result.Match(
                deleteQuestionResult => Ok(deleteQuestionResult),
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