using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IAnswerDateRepository
    {
        AnswerDates GetLastAnswerDate(int userId);
        AnswerDates UpdateAnswerDate(int userId);
        AnswerDates CreateAnswerDate(int userId);

    }
}
