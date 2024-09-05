using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly ToursContext _dbContext;

        public QuestionnaireRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public Questionnaire GetRandomQuestion()
        {
            var totalCount = _dbContext.Questionnaire.Count();
            if(totalCount == 0)
            {
                return null;
            }
            var randomIndex = new Random().Next(1, totalCount+1);

            var questionnaire = _dbContext.Questionnaire.FirstOrDefault(q => q.Id == randomIndex);

            return questionnaire;
        }
    }
}
