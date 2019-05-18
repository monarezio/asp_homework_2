using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using TechSupport.Hubs;
using TechSupportData.Models;
using TechSupportData.Repositories.Questions;
using TechSupportData.Repositories.Resolutions;

namespace TechSupport.Pages
{
    public class Answer : PageModel
    {

        private readonly IQuestionsRepository _questionsRepository;
        private readonly IResolutionRepository _resolutionRepository;
        private readonly IHubContext<QuestionHub> _hubContext;

        [BindProperty(SupportsGet = true)]
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public Answer(IQuestionsRepository questionsRepository, IResolutionRepository resolutionRepository, IHubContext<QuestionHub> hubContext)
        {
            _questionsRepository = questionsRepository;
            _resolutionRepository = resolutionRepository;
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
            Question = _questionsRepository.Get(QuestionId);
            if (Question == null)
                return RedirectToPage("Questions");

            return Page();
        }

        public IActionResult OnPost(Resolution resolution, IFormFile file)
        {
            if (string.IsNullOrEmpty(resolution.Answer))
            {
                return OnGet();
            }

            _resolutionRepository.AddResolution(resolution, file);
            
            _hubContext.Clients.All.SendAsync("Decrement");
            return RedirectToPage("Questions");
        }
    }
}