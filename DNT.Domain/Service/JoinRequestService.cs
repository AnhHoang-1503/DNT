
using AutoMapper;
using DNT.Domain.Common;

namespace DNT.Domain
{
    public class JoinRequestService : BaseService<JoinRequest, JoinRequestDto, JoinRequestCUDto>
    {
        private readonly UserSessionState _userSessionState;
        private readonly IJoinRequestRepository _joinRequestRepository;

        public JoinRequestService(IJoinRequestRepository joinRequestRepository, UserSessionState userSessionState, IMapper mapper) : base(joinRequestRepository, mapper)
        {
            _userSessionState = userSessionState;
            _joinRequestRepository = joinRequestRepository;
        }

        public async Task<IEnumerable<JoinRequestDto>> GetByOrganization_Id(Guid organizationId)
        {
            var request = await _joinRequestRepository.GetByOrganization_Id(organizationId);

            var joinRequestDtos = _mapper.Map<IEnumerable<JoinRequestDto>>(request);

            return joinRequestDtos;
        }

        public override JoinRequest MapCUDtoToEntity(JoinRequestCUDto entityCUDto)
        {
            var joinRequest = _mapper.Map<JoinRequest>(entityCUDto);

            joinRequest.Id = Guid.NewGuid();
            joinRequest.Status = Status.initial;

            if (_userSessionState.Id.HasValue)
            {
                joinRequest.User_Id = _userSessionState.Id.Value;
            }

            return joinRequest;
        }

        public override JoinRequest MapCUDtoToEntity(JoinRequestCUDto entityCUDto, Guid id)
        {
            var joinRequest = _mapper.Map<JoinRequest>(entityCUDto);

            joinRequest.Id = id;

            if (_userSessionState.Id.HasValue)
            {
                joinRequest.User_Id = _userSessionState.Id.Value;
            }

            return joinRequest;
        }
    }
}
