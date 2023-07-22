using QamarKitoblar.DataAccess.Utils;

namespace QamarKitoblar.DataAccess.Common.Interfaces
{
    public interface ISearchable<TViewModel>
    {
        public Task<(int ItemsCount, IList<TViewModel>)> SearchAsync(string search, PaginationParams @params);
    }
}
