using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LifeLine.Core.Models;
using LifeLine.Infrastructure;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LifeLine.Web.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class EligibilityController : ApiController
    {
        private readonly BloodDonorContext _context=  new BloodDonorContext();
        
        /// <summary>
        /// Return the first question for the logged in user on first landing on the page
        /// </summary>
        /// <returns></returns>
        //GET: api/Eligibility
        [System.Web.Http.HttpGet]
        public EligibilityQuestion Get()
        {
            var userId = User.Identity.Name;

            EligibilityQuestion nextQuestion = NextQuestionAsync(userId);
            
            return nextQuestion;
        }

        /// <summary>
        /// Saves the last question selected by the user and returns the next question for the logged in user
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        // POST: api/Eligibility
        [System.Web.Mvc.HttpPost]
        public EligibilityQuestion Post([System.Web.Http.FromBody] EligibilityAnswer answer)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                throw new Exception();
            }

            answer.UserId = User.Identity.Name;

            var isCorrect = StoreAnswer(answer);

            /*************/
            return NextQuestionAsync(User.Identity.Name);
            /*****************************/

            //return this.CreatedAtRoute("Get", new { }, isCorrect);
        }

        /// <summary>
        /// Return the first question for the logged in user on first landing on the page
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private EligibilityQuestion NextQuestionAsync(string userId)
        {
            var lastQuestionId = this._context.EligibilityAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => q.Count)
                .ThenByDescending(q => q.QuestionId)
                .Select(q => q.QuestionId)
                .FirstOrDefault();

            var questionsCount = this._context.EligibilityQuestions.Count();

            //if last question is equal to the number of questions 
            //return the final eligible or not eligible message
            if (lastQuestionId == questionsCount)
            {
               EligibilityQuestion next = new EligibilityQuestion
               {
                   Title = "Eligible",
                   Options = (new EligibilityOption[]
                    {
                        new EligibilityOption { Title= "OK", IsCorrect= true },
                    }).ToList()
               };

                return next;
            }

            var nextQuestionId = (lastQuestionId % questionsCount) + 1;
            return this._context.EligibilityQuestions.Include(q => q.Options).FirstOrDefault(q => q.Id == nextQuestionId);
        }

        /// <summary>
        /// Saves the last question selected by the user
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        private bool StoreAnswer(EligibilityAnswer answer)
        {
            var selectedOption = this._context.EligibilityOptions.FirstOrDefault(o =>
                o.Id == answer.OptionId
                && o.QuestionId == answer.QuestionId);

            if (selectedOption != null)
            {
                answer.EligibilityOption = selectedOption;
                _context.EligibilityAnswers.Add(answer);

                _context.SaveChanges();
            }

            return selectedOption != null && selectedOption.IsCorrect;
        }
    }
}
