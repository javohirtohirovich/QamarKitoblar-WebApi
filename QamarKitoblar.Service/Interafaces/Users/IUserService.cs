using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.DataAccess.ViewModels.UsersVM;
using QamarKitoblar.Domain.Entities.Publishers;
using QamarKitoblar.Domain.Entities.Users;
using QamarKitoblar.Service.Dtos.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Interafaces.Users;

public interface IUserService
{
    public Task<bool> DeleteAsync(long PublisherId);
    public Task<long> CountAsync();
    public Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params);
}
