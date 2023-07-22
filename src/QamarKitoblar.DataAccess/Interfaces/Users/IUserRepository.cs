using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Users;

namespace QamarKitoblar.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, User>, IGetAll<User>, ISearchable<User>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
