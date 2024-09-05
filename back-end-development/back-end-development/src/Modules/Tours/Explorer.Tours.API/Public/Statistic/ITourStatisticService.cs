using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Statistic
{
    public interface ITourStatisticService
    {
        //Dodati zaglavlja metoda koje budu implementirane u TourStatistic servisu
        Result<SingleTourStatisticDto> CalculateStatistic(int tourId);

    }
}
