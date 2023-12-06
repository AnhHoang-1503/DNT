using AutoMapper;

namespace DNT.Domain.Service
{
    public class ForHelpRequestService : BaseService<ForHelpRequest, ForHelpRequestDto, ForHelpRequestCUDto>
    {
        public ForHelpRequestService(IForHelpRequestRepository forHelpRequestRepository, IMapper mapper) : base(forHelpRequestRepository, mapper)
        {
        }

        public override ForHelpRequest MapCUDtoToEntity(ForHelpRequestCUDto entityCUDto)
        {
            var forHelpRequest = _mapper.Map<ForHelpRequest>(entityCUDto);

            forHelpRequest.User_id = Guid.Parse(entityCUDto.User_id);
            forHelpRequest.Organization_Id = Guid.Parse(entityCUDto.Organization_Id);

            if (forHelpRequest.Id == Guid.Empty)
            {
                forHelpRequest.Id = Guid.NewGuid();
            }

            return forHelpRequest;
        }
    }
}
