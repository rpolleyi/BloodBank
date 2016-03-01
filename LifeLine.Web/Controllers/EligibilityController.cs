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

namespace LifeLine.Web.Controllers
{
    //[Produces("application/json")]
    //[System.Web.Mvc.Route("api/[Eligibility]")]
    [System.Web.Mvc.Authorize]
    public class EligibilityController : ApiController
    {
        private BloodDonorContext context=  new BloodDonorContext();


        //[System.Web.Http.HttpGet]
        //public List<EligibilityQuestion> GetAll()
        //{
        //    return context.EligibilityQuestions.ToList();
        //}

        //GET: api/Eligibility
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;

            EligibilityQuestion nextQuestion = await NextQuestionAsync(userId);

            if (nextQuestion == null)
            {
                return NotFound();
            }

            return Ok(nextQuestion);
        }

        // POST: api/Eligibility
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Post([System.Web.Http.FromBody] EligibilityAnswer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            answer.UserId = User.Identity.Name;

            var isCorrect = this.StoreAsync(answer);

            return this.CreatedAtRoute("Get", new { }, isCorrect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<EligibilityQuestion> NextQuestionAsync(string userId)
        {
            var lastQuestionId = await this.context.EligibilityAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => q.Count)
                .ThenByDescending(q => q.QuestionId)
                .Select(q => q.QuestionId)
                .FirstOrDefaultAsync();

            var questionsCount = await this.context.EligibilityQuestions.CountAsync();

            var nextQuestionId = (lastQuestionId % questionsCount) + 1;
            return await this.context.EligibilityQuestions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == nextQuestionId);
        }

        private async Task<bool> StoreAsync(EligibilityAnswer answer)
        {
            var selectedOption = await this.context.EligibilityOptions.FirstOrDefaultAsync(o =>
                o.Id == answer.OptionId
                && o.QuestionId == answer.QuestionId);

            if (selectedOption != null)
            {
                answer.EligibilityOption = selectedOption;
                this.context.EligibilityAnswers.Add(answer);

                await this.context.SaveChangesAsync();
            }

            return selectedOption != null && selectedOption.IsCorrect;
        }
    }
}
