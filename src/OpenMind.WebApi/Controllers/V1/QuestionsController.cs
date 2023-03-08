using Microsoft.AspNetCore.Mvc;

namespace OpenMind.WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class QuestionsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetQuestions()
        {
            return Ok("All questions retrieved by V1.");
        }
    }
}
