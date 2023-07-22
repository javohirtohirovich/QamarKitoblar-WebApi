using QamarKitoblar.DataAccess.Utils;

namespace QamarKitoblar.DataAccess.Common.Interfaces
{
    public interface IGetAll<TViewModel>
    {
        public Task<IList<TViewModel>> GetAllAsync(PaginationParams @params);
    }
}
