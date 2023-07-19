using QamarKitoblar.Service.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Interafaces.Geners
{
    public interface IGenerService
    {
        public Task<bool> CreateAsync(GenerCreateDto dto);
        public Task<bool> DeleteAsync(long GenerId);
        public Task<long> CountAsync();
    }
}
