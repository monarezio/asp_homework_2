using System.ComponentModel.DataAnnotations;
using TechSupportData.Models;
using TechSupportData.Models.Attributes;

namespace TechSupport.Models
{
    public class QuestionViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [ClientEmail]
        public string Email { get; set; }
        [Required]
        public string Body { get; set; }

        public int QuestionId { get; set; }

        public QuestionViewModel() { }
        
        public QuestionViewModel(Question question)
        {
            ProductId = question.ProductId;
            Email = question.Email;
            Body = question.Body;
            QuestionId = question.QuestionId;
        }

        //TODO: Maybe put it somewhere else?
        public Question ToQuestion()
        {
            return new Question
            {
                ProductId = ProductId,
                Email = Email,
                Body = Body
            };
        }
    }
}