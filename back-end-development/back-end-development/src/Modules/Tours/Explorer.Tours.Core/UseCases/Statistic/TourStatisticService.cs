using Explorer.Payments.API.Internal;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.API.Public.Statistic;
using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Statistic
{
    public class TourStatisticService : ITourStatisticService
    {
        private readonly IInternalOrderService _orderService;
        private readonly ITourExecutionService _tourExecutionService;
        private readonly ICheckpointService _checkpointService;
        public TourStatisticService(IInternalOrderService orderService, ITourExecutionService tourExecutionService, ICheckpointService checkpointService)
        {
            _orderService = orderService;
            _tourExecutionService = tourExecutionService;
            _checkpointService = checkpointService;
        }

        //TODO: implementacija funkcija

        public Result<SingleTourStatisticDto> CalculateStatistic(int tourId)
        {
            SingleTourStatisticDto singleTourStatisticDto = new SingleTourStatisticDto(
                GetNumberOfSalesForTour(tourId).Value,
                GetCountOfExecutionsForTour(tourId).Value,
                GetNumberOfFinishesOfTour(tourId).Value,
                GetCheckpointsCompletionsPercentages(tourId).Value
                );

            return singleTourStatisticDto;
        }

        private Result<int> GetNumberOfSalesForTour(int tourId)
        {
            return _orderService.GetOrderCount(tourId);
        }

        private Result<int> GetCountOfExecutionsForTour(int tourId)
        {
            return _tourExecutionService.GetCountOfExecutionsForTour(tourId);
        }

        private Result<int> GetNumberOfFinishesOfTour(int tourId)
        {
            return _tourExecutionService.GetNumberOfFinishesOfTour(tourId);
        }

        private Result<Dictionary<string,double>> GetCheckpointsCompletionsPercentages(int tourId)
        {
            List<TourExecutionDto> executions = _tourExecutionService.GetAllExecutionsForTour(tourId).Value;
            Dictionary<long,int> checkpointCompleted = GetCheckpointsDictionary(tourId);

            foreach (TourExecutionDto execution in executions)
            {
                foreach(CheckpointStatusDto checkpointStatus in execution.CheckpointStatuses)
                {
                    if (checkpointStatus.IsCompleted)
                    {
                        if (checkpointCompleted.ContainsKey(checkpointStatus.CheckpointId))
                        {
                            checkpointCompleted[checkpointStatus.CheckpointId]++;
                        }
                    }
                }
            }

            return CalculatePercentage(checkpointCompleted, executions.Count);
            
        }

        private Dictionary<long,int> GetCheckpointsDictionary(int tourId)
        {
            Dictionary<long, int> checkpointsCompleted = new Dictionary<long, int>();
            List<CheckpointDto> checkpointDtos = _checkpointService.GetAllByTourId(0, 0, tourId).Value.Results;
            foreach (CheckpointDto checkpoint in checkpointDtos)
            {
                checkpointsCompleted.Add(checkpoint.Id, 0);
            }
            return checkpointsCompleted;
        }

        private Dictionary<String,double> CalculatePercentage(Dictionary<long,int> checkpointCompleted, int numOfExecutions)
        {
            Dictionary<String,double> checkpointNamePercentage = new Dictionary<String,double>();
            foreach(KeyValuePair<long,int> kvp in checkpointCompleted)
            {
                double percentage = 0;
                if(numOfExecutions != 0)
                {
                   percentage = (double)kvp.Value / numOfExecutions * 100;
                   percentage = Math.Round(percentage, 1);
                }
                
                string checkpointName = _checkpointService.Get((int)kvp.Key).Value.Name;

                checkpointNamePercentage.Add(checkpointName, percentage);
            }

            return checkpointNamePercentage;
        }
    }
}
