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
        public ForHelpRequestController(ForHelpRequestService forHelpRequestService) : base(forHelpRequestService)
        {
        }
    }
}
