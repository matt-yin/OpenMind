using Microsoft.AspNetCore.Mvc;

namespace OpenMind.WebApi.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    public class QuestionsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetQuestions()
        {
            return Ok("All questions retrieved by V2.");
        }
    }
}
