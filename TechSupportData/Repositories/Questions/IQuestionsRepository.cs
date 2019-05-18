using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using TechSupportData.Models;

namespace TechSupportData.Repositories.Questions
{
    public interface IQuestionsRepository
    {

        Question AddQuestion(Question question, IFormFile file);

        IList<Question> GetOldest(int limit = 10);

        Question Get(int questionId);

        int Count();

    }
}