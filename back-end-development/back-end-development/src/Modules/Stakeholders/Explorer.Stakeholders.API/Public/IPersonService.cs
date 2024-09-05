using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IPersonService
    {
        Result<UpdatePersonDTO> GetByUserId(int id);
        Result<UpdatePersonDTO> UpdatePerson(UpdatePersonDTO updatePerson,int personId);
        public Result<string> GetPersonEmail(long personId);
    }
}
