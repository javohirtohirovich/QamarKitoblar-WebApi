using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Geners;
using QamarKitoblar.Service.Dtos.Categories;

namespace QamarKitoblar.Service.Interafaces.Geners
{
    public interface IGenerService
    {
        public Task<bool> CreateAsync(GenerCreateDto dto);
        public Task<bool> DeleteAsync(long GenerId);
        public Task<long> CountAsync();
        public Task<bool> UpdateAsync(long GenerId, GenerUpdateDto dto);
        public Task<Gener> GetByIdAsync(long GenerId);
        public Task<IList<Gener>> GetAllAsync(PaginationParams @params);
    }
}
