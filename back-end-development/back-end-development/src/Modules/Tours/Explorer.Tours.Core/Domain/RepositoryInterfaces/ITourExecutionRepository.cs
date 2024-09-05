using Explorer.Tours.Core.Domain.TourExecutions;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces;

public interface ITourExecutionRepository
{
    TourExecution Get(long id);
    TourExecution GetUntracked(long id);
    List<TourExecution> GetAll();
    TourExecution Create(TourExecution execution);
    TourExecution Update(TourExecution execution);
    void Delete(long id);
    Result<int> GetCountOfExecutionsForTour(int tourId);
    Result<int> GetNumberOfFinishesOfTour(int tourId);
    Result<List<TourExecution>> GetAllExecutionsForTour(int tourId);
    TourExecution GetByUserAndTourId(long userId, long tourId);
    List<TourExecution> GetAllFinishedForTourist(long userId);
}
