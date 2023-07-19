using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Geners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Interfaces.Geners
{
    public interface IGenerRepository:IRepository<Gener,Gener>,IGetAll<Gener>
    {
    }
}
