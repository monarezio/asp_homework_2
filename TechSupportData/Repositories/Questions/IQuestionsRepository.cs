using System.IO;
using TechSupportData.Models;

namespace TechSupportData.Repositories.Questions
{
    public interface IQuestionsRepository
    {

        Question AddQuestion(Question question, FileStream fileStream);

    }
}