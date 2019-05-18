using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechSupportData.Models;

namespace TechSupportData.Repositories.Questions
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly TechSupportDbContext _dbContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public QuestionsRepository(TechSupportDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public Question AddQuestion(Question question, IFormFile file = null)
        {
            if (file != null)
            {
                question.AttachmentFileName = System.Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.Combine(_hostingEnvironment.WebRootPath, "resources/questions/attachments");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fullPath = Path.Combine(path, question.AttachmentFileName);

                FileStream outputFileStream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(outputFileStream);
            }

            EntityEntry<Question> entry = _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();

            return entry.Entity;
        }

        public IList<Question> GetOldest(int limit = 10)
        {
            return _dbContext.Questions
                .Include(i => i.Resolution)
                .Where(i => i.Resolution == null)
                .Take(limit)
                .ToList();
        }

        public Question Get(int questionId)
        {
            return _dbContext.Questions
                .Include(i => i.Product)
                .FirstOrDefault(i => i.QuestionId == questionId);
        }

        public int Count()
        {
            return _dbContext.Questions
                .Include(i => i.Resolution)
                .Where(i => i.Resolution == null)
                .Count();
        }
    }
}