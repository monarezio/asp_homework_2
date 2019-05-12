using System.IO;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechSupportData.Models;

namespace TechSupportData.Repositories.Questions
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly TechSupportDbContext _dbContext;

        public QuestionsRepository(TechSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Question AddQuestion(Question question, FileStream fileStream = null)
        {
            if (fileStream != null)
            {
                Directory.CreateDirectory("resources/questions/images");
            
                FileStream outputFileStream = File.Create("resources/questions/images");
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.CopyTo(outputFileStream);
                outputFileStream.Close();

                question.IsAttachment = true;
            }

            EntityEntry<Question> entry = _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();
            
            return entry.Entity;
        }
    }
}