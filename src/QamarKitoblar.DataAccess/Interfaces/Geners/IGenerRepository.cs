using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Geners;

namespace QamarKitoblar.DataAccess.Interfaces.Geners
{
    public interface IGenerRepository : IRepository<Gener, Gener>, IGetAll<Gener>
    {
    }
}
