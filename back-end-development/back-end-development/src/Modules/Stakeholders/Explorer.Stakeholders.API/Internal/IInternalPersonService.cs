using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Internal
{
    public interface IInternalPersonService
    {
        Result<string> GetName(long personId);
        Result<string> GetSurname(long personId);
        Result<StakeholdersCoordinateDto> GetPersonLocation(long personId);

    }
}
