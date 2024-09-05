using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class AnswerDatesRepository : IAnswerDateRepository
    {
        private readonly ToursContext _dbContext;

        public AnswerDatesRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AnswerDates GetLastAnswerDate(int userId)
        {
            var lastAnswerDate = _dbContext.AnswerDates.FirstOrDefault(i => i.userId == userId);
            if(lastAnswerDate == null)
            {
                return null;
            }
            return lastAnswerDate;
        }
        
        public AnswerDates UpdateAnswerDate(int userId)
        {
            var existingAnswerDate = _dbContext.AnswerDates.FirstOrDefault(i => i.userId == userId);
            if (existingAnswerDate != null)
            {
                // Ažurirajte datum postojećeg zapisa
                existingAnswerDate.lastAnswerDate = DateTime.UtcNow;
                _dbContext.SaveChanges();
                return existingAnswerDate;
            }

            return CreateAnswerDate(userId);
        }

        public AnswerDates CreateAnswerDate(int userId)
        {
            AnswerDates answerDate = new AnswerDates(userId, DateTime.UtcNow);
            _dbContext.Add(answerDate);
            _dbContext.SaveChanges();
            return answerDate;
        }

        
    }
}
