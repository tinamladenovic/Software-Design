using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Explorer.Tours.API.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases
{
    public class QuestionnaireService : CrudService<QuestionnaireDto,Questionnaire> ,IQuestionnaireService
    {
        protected readonly ICrudRepository<Questionnaire> CrudRepository;
        private readonly IQuestionnaireRepository QuestionnaireRepository;

        public QuestionnaireService(ICrudRepository<Questionnaire> repository,IQuestionnaireRepository questionnaireRepository, IMapper mapper) : base(repository, mapper)
        {
            CrudRepository = repository;
            QuestionnaireRepository = questionnaireRepository;

        }

        public Result<QuestionnaireDto> GetRandomQuestion()
        {
            var result = QuestionnaireRepository.GetRandomQuestion();
            return MapToDto(result);
        }

    }
}
