using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Publishers;

namespace QamarKitoblar.DataAccess.Interfaces.Publishers
{
    public interface IPublisherRepository : IRepository<Publisher, Publisher>, IGetAll<Publisher>
    {
    }
}
