using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Publishers;
using QamarKitoblar.Service.Dtos.Publishers;

namespace QamarKitoblar.Service.Interafaces.Publishers
{
    public interface IPublisherService
    {
        public Task<bool> CreateAsync(PublisherCreateDto dto);
        public Task<bool> DeleteAsync(long PublisherId);
        public Task<long> CountAsync();
        public Task<bool> UpdateAsync(long PublisherId, PublisherUpdateDto dto);
        public Task<Publisher> GetByIdAsync(long PublisherId);
        public Task<IList<Publisher>> GetAllAsync(PaginationParams @params);
    }
}
