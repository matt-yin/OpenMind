using Microsoft.AspNetCore.Mvc;

namespace OpenMind.WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class QuestionsController : ControllerBase
    {
        /// <summary>
        /// Get all questions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetQuestions()
        {
            return Ok("All questions retrieved by V1.");
        }

        /// <summary>
        /// Get all answers for the given question.
        /// </summary>
        /// <param name="questionId"> The given question.</param>
        /// <returns></returns>
        [HttpGet("{questionId}/answers")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> GetAnswers(int questionId)
        {
            return Ok($"All answers for question {questionId} retrieved.");
        }
    }
}
