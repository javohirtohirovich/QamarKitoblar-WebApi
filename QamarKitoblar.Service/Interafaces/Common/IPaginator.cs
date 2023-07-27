using QamarKitoblar.DataAccess.Utils;
namespace QamarKitoblar.Service.Interafaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
