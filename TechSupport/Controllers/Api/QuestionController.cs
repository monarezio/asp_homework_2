using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TechSupport.Hubs;
using TechSupport.Models;
using TechSupportData.Models;
using TechSupportData.Repositories.Questions;

namespace TechSupport.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IHubContext<QuestionHub> _hubContext;

        public QuestionController(IQuestionsRepository questionsRepository, IHubContext<QuestionHub> hubContext)
        {
            _questionsRepository = questionsRepository;
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("[action]")]
        public JsonResult AddPost()
        {
            return Json("Test");
        }

        [HttpPost]
        [Route("[action]")]
        public JsonResult Add([FromForm] QuestionViewModel question, IFormFile file)
        {
            Question entry = _questionsRepository.AddQuestion(question.ToQuestion(), file);
            _hubContext.Clients.All.SendAsync("Increment");
            return Json(question);
        }
    }
}