using DNT.Controllers.Base;
using DNT.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinRequestController : BaseController<JoinRequest, JoinRequestDto, JoinRequestCUDto>
    {
        private readonly JoinRequestService _joinRequestService;

        public JoinRequestController(JoinRequestService joinRequestService) : base(joinRequestService)
        {
            _joinRequestService = joinRequestService;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<IActionResult> GetByOrganization_Id(Guid organizationId)
        {
            var joinRequests = await _joinRequestService.GetByOrganization_Id(organizationId);

            return StatusCode(StatusCodes.Status200OK, joinRequests);
        }
    }
}
