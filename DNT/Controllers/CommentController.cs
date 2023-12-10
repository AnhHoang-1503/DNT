using DNT.Controllers.Base;
using DNT.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController<Comment, CommentDto, CommentCUDto>
    {
        public CommentController(CommentService commentService) : base(commentService)
        {
        }

    }
}
