using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    //[Authorize(Policy = "touristPolicy")]
    [Route("api/questionnaire/")]
    public class QuestionnaireController : BaseApiController
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IAnswerDatesService _answerDatesService;

        public QuestionnaireController(IQuestionnaireService questionnaireService, IAnswerDatesService answerDatesService)
        {
            _questionnaireService = questionnaireService;
            _answerDatesService = answerDatesService;
        }

        [HttpGet("getQuestion")]
        public ActionResult<QuestionnaireDto> GetRandomQuestion()
        {
            var result = _questionnaireService.GetRandomQuestion();
            return CreateResponse(result);
        }

        [HttpGet("getLastAnswerDate/{userId:int}")]
        public ActionResult<AnswerDateDto> getLastAnswerDate(int userId)
        {
            var result = _answerDatesService.GetAnswerDateByUserId(userId);
            return CreateResponse(result);
        }

        [HttpPost("createOrUpdateLastAnswerDate/{userId:int}")]   
        public ActionResult<AnswerDateDto> CreateOrUpdateLastAnswerDate(int userId)
        {
            var result = _answerDatesService.UpdateAnswerDate(userId);
            return CreateResponse(result);
        }
    }
}
