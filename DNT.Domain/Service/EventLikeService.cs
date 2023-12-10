
using AutoMapper;
using DNT.Domain.Common;

namespace DNT.Domain
{
    public class EventLikeService : BaseService<EventLike, EventLikeDto, EventLikeCUDto>
    {
        private readonly UserSessionState _userSessionState;

        public EventLikeService(IEventLikeRepository eventLikeRepository, UserSessionState userSessionState, IMapper mapper) : base(eventLikeRepository, mapper)
        {
            _userSessionState = userSessionState;
        }

        public override EventLike MapCUDtoToEntity(EventLikeCUDto entityCUDto)
        {
            var eventLike = _mapper.Map<EventLike>(entityCUDto);

            if (_userSessionState.Id.HasValue)
            {
                eventLike.User_Id = _userSessionState.Id.Value;
            }

            return eventLike;
        }

        public override EventLike MapCUDtoToEntity(EventLikeCUDto entityCUDto, Guid id)
        {
            var eventLike = _mapper.Map<EventLike>(entityCUDto);
            eventLike.Id = id;

            if (_userSessionState.Id.HasValue)
            {
                eventLike.User_Id = _userSessionState.Id.Value;
            }

            return eventLike;
        }
    }
}
