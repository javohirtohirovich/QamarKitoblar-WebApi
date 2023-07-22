using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Geners;
using QamarKitoblar.Domain.Entities.Publishers;
using QamarKitoblar.Service.Dtos.Categories;
using QamarKitoblar.Service.Dtos.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
