
using AutoMapper;
using DNT.Domain.Common;

namespace DNT.Domain
{
    public class CommentService : BaseService<Comment, CommentDto, CommentCUDto>
    {
        private readonly UserSessionState _userSessionState;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, UserSessionState userSessionState) : base(commentRepository, mapper)
        {
            _userSessionState = userSessionState;
        }

        public override Comment MapCUDtoToEntity(CommentCUDto entityCUDto)
        {
            var comment = _mapper.Map<Comment>(entityCUDto);

            if (_userSessionState.Id.HasValue)
            {
                comment.User_Id = _userSessionState.Id.Value;
            }

            return comment;
        }

        public override Comment MapCUDtoToEntity(CommentCUDto entityCUDto, Guid id)
        {
            var comment = _mapper.Map<Comment>(entityCUDto);
            comment.Id = id;

            if (_userSessionState.Id.HasValue)
            {
                comment.User_Id = _userSessionState.Id.Value;
            }

            return comment;
        }
    }
}
