using DNT.Controllers.Base;
using DNT.Domain;
using DNT.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForHelpRequestController : BaseController<ForHelpRequest, ForHelpRequestDto, ForHelpRequestCUDto>
    {
        private readonly ForHelpRequestService _forHelpRequestService;

        public ForHelpRequestController(ForHelpRequestService forHelpRequestService) : base(forHelpRequestService)
        {
            _forHelpRequestService = forHelpRequestService;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<IActionResult> GetByOrganizationId(Guid organizationId)
        {
            var forHelpRequestDtos = await _forHelpRequestService.GetByOrganizationId(organizationId);

            return StatusCode(StatusCodes.Status200OK, forHelpRequestDtos);
        }

        [HttpPost("action/{id}")]
        public async Task<IActionResult> Action(Guid id, [FromQuery] bool approved)
        {
            await _forHelpRequestService.Action(id, approved);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
