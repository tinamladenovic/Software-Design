using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ISaleRepository
    {
        List<Sale> GetAllForAuthor(long id);
        Sale GetById(long id);
        Sale Create(Sale entity);
    }
}
