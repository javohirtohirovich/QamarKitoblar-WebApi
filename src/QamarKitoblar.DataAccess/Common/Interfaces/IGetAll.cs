using QamarKitoblar.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Common.Interfaces
{
    public interface IGetAll<TViewModel>
    {
        public Task<IList<TViewModel>> GetAllAsync(PaginationParams @params);
    }
}
