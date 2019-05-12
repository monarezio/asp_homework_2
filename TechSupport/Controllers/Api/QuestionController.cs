using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSupportData.Models;
using TechSupportData.Repositories.Questions;

namespace TechSupport.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionController(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult Add(Question question, IFormFile file)
        {
            string filePath = Path.GetTempFileName();
            FileStream stream; 
            using (stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            try
            {
                Question entry = _questionsRepository.AddQuestion(question, stream);
                
                stream.Close();
                System.IO.File.Delete(filePath); //Remove useless temp file
                
                return Ok(entry);
            }
            catch(Exception e)
            {
                //TODO: Do something interesting
                throw e;
            }
        }

    }
}