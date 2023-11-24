namespace DNT.Domain
{
    public abstract class BaseService<TEntity>
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;

        protected BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Lay tat ca ban ghi
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var entities = await _baseRepository.GetAll();
            return entities;
        }

        /// <summary>
        /// Lay ban ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetById(Guid id)
        {
            var entity = await _baseRepository.GetById(id);

            if (entity == null)
            {
                throw new Exception("Not found");
            }

            return entity;
        }

        /// <summary>
        /// tim ban ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> FindById(Guid id)
        {
            var entity = await _baseRepository.FindById(id);

            return entity;
        }

        /// <summary>
        /// Tao ban ghi moi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Create(TEntity entity)
        {
            await _baseRepository.Create(entity);
        }

        /// <summary>
        /// Chinh sua ban ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(Guid id, TEntity entity)
        {
            await _baseRepository.Update(id, entity);
        }

        /// <summary>
        /// Xoa ban ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            await _baseRepository.Delete(id);
        }

        /// <summary>
        /// Xoa nhieu ban ghi
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task DeleteMany(List<Guid> ids)
        {
            await _baseRepository.DeleteMany(ids);
        }
    }
}
