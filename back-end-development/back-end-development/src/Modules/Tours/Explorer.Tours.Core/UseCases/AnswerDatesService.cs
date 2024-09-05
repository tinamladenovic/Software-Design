using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class AnswerDatesService : CrudService<AnswerDateDto, AnswerDates>, IAnswerDatesService
    {
        protected readonly ICrudRepository<AnswerDates> CrudRepository;
        protected readonly IAnswerDateRepository AnswerRepository;

        public AnswerDatesService(ICrudRepository<AnswerDates> repository, IAnswerDateRepository answerRepository, IMapper mapper) : base(repository, mapper)
        {
            CrudRepository = repository;
            AnswerRepository = answerRepository;
        }

        public Result<AnswerDateDto> GetAnswerDateByUserId(int userId)
        {
            var result = AnswerRepository.GetLastAnswerDate(userId);
            return MapToDto(result);
        }

        public Result<AnswerDateDto> UpdateAnswerDate(int userId)
        {
            var result = AnswerRepository.UpdateAnswerDate(userId);
            return MapToDto(result);
        }
    }
}
