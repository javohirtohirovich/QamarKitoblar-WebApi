using QamarKitoblar.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Common.Interfaces
{
    public interface ISearchable<TViewModel>
    {
        public Task<(int ItemsCount, IList<TViewModel>)> SearchAsync(string search, PaginationParams @params);
    }
}
