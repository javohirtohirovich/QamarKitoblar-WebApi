using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.DataAccess.ViewModels.UsersVM;
using QamarKitoblar.Domain.Entities.Users;

namespace QamarKitoblar.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, User>, IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
