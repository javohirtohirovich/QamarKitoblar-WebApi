using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Interfaces.Users;

public interface IUserRepository:IRepository<User, User>,IGetAll<User>,ISearchable<User>
{
}
