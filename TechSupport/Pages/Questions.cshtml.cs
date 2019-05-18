using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechSupport.Models;
using TechSupportData.Repositories.Questions;

namespace TechSupport.Pages
{
    public class Questions : PageModel
    {
        private readonly IQuestionsRepository _questionsRepository;

        public IList<QuestionViewModel> QuestionsList { get; set; }

        public int QuestionCount { get; set; }

        public Questions(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public void OnGet()
        {
            QuestionCount = _questionsRepository.Count();
            QuestionsList = _questionsRepository
                .GetOldest()
                .Select(i =>
                    new QuestionViewModel(i)
                )
                .ToList();
        }
    }
}