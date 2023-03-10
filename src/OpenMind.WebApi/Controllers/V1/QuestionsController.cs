using Microsoft.AspNetCore.Mvc;
using OpenMind.WebApi.Models.V1;

namespace OpenMind.WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class QuestionsController : ControllerBase
    {
        private static readonly IEnumerable<QuestionInfo> _questions = new List<QuestionInfo>
        {
            new QuestionInfo
            {
                QuesitonId = 1,
                Title = $"Title 1",
                Content = "Question 1",
                UserId = 1,
                Created = DateTime.UtcNow,
                Answers = new List<AnswerInfo> 
                {
                    new AnswerInfo
                    {
                        AnswerId = 1,
                        Content = "Answer",
                        UserId = 3,
                        Created = DateTime.UtcNow
                    }
                }
            },
            new QuestionInfo
            {
                QuesitonId = 2,
                Title = "Title 2",
                Content = "Question 2",
                UserId = 2,
                Created = DateTime.UtcNow
            }
        };

        /// <summary>
        /// Get all questions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<QuestionInfo>>> GetQuestions()
        {
            return Ok(_questions);
        }

        /// <summary>
        /// Get question by ID.
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <returns></returns>
        [HttpGet("{questionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<QuestionInfo>>> GetQuestionById(int questionId)
        {
            var question = _questions.FirstOrDefault(q => q.QuesitonId == questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        /// <summary>
        /// Get all answers for the specified question.
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <returns></returns>
        [HttpGet("{questionId}/answers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AnswerInfo>>> GetAnswers(int questionId)
        {
            var question = _questions.FirstOrDefault(q => q.QuesitonId == questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question.Answers);
        }

        /// <summary>
        /// Get all answers for the specified question.
        /// </summary>
        /// <param name="questionId">Question ID</param>
        /// <param name="answerId">Answer ID</param>
        /// <returns></returns>
        [HttpGet("{questionId}/answers/{answerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AnswerInfo>> GetAnswerById(int questionId, int answerId)
        {
            var question = _questions.FirstOrDefault(q => q.QuesitonId == questionId);
            if (question == null)
            {
                return NotFound();
            }
            var answer = question.Answers?.FirstOrDefault(a => a.AnswerId == answerId);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }
    }
}
