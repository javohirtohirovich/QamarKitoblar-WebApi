using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Interfaces.Publishers
{
    public interface IPublisherRepository:IRepository<Publisher, Publisher>,IGetAll<Publisher>
    {
    }
}
