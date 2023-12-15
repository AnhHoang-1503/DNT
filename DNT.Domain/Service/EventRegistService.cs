
using AutoMapper;

namespace DNT.Domain
{
    public class EventRegistService : BaseService<EventRegist, EventRegistDto, EventRegistCUDto>
    {
        private readonly IEventRegistRepository _eventRegistRepository;

        public EventRegistService(IEventRegistRepository eventRegistRepository, IMapper mapper) : base(eventRegistRepository, mapper)
        {
            _eventRegistRepository = eventRegistRepository;
        }

        public async Task<int> CountRegisterByEventId(Guid id)
        {
            var eventRegists = await _eventRegistRepository.FindByEventId(id);

            var count = eventRegists.Count();

            return count;
        }

        public override EventRegist MapCUDtoToEntity(EventRegistCUDto entityCUDto)
        {
            var eventRegist = _mapper.Map<EventRegist>(entityCUDto);

            eventRegist.Id = Guid.NewGuid();

            return eventRegist;
        }

        public override EventRegist MapCUDtoToEntity(EventRegistCUDto entityCUDto, Guid id)
        {
            var eventRegist = _mapper.Map<EventRegist>(entityCUDto);

            eventRegist.Id = id;

            return eventRegist;
        }
    }
}
