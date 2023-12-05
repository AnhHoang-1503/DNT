using AutoMapper;

namespace DNT.Domain
{
    public abstract class BaseService<TEntity, TEntityDto, TEntityCUDto>
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;

        protected readonly IMapper _mapper;

        protected BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Lay tat ca ban ghi
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntityDto>> GetAll()
        {
            var entities = await _baseRepository.GetAll();

            var entityDtos = _mapper.Map<IEnumerable<TEntityDto>>(entities);

            return entityDtos;
        }

        /// <summary>
        /// Lay ban ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntityDto> GetById(Guid id)
        {
            var entity = await _baseRepository.GetById(id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            var entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }

        /// <summary>
        /// tim ban ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntityDto?> FindById(Guid id)
        {
            var entity = await _baseRepository.FindById(id);

            var entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }

        /// <summary>
        /// Tao ban ghi moi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task Create(TEntityCUDto entityCUDto)
        {
            var entity = MapCUDtoToEntity(entityCUDto);

            await _baseRepository.Create(entity);
        }

        /// <summary>
        /// Chinh sua ban ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task Update(Guid id, TEntityCUDto entityCUDto)
        {
            var entity = MapCUDtoToEntity(entityCUDto);

            await _baseRepository.Update(id, entity);
        }

        /// <summary>
        /// Xoa ban ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task Delete(Guid id)
        {
            await _baseRepository.Delete(id);
        }

        /// <summary>
        /// Xoa nhieu ban ghi
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual async Task DeleteMany(List<Guid> ids)
        {
            await _baseRepository.DeleteMany(ids);
        }

        public abstract TEntity MapCUDtoToEntity(TEntityCUDto entityCUDto);
    }
}
