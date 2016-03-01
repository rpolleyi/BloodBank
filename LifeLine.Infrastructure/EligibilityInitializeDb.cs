using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using LifeLine.Core.Models;

namespace LifeLine.Infrastructure
{
    public class EligibilityInitializeDb : DropCreateDatabaseIfModelChanges<EligibilityContext>
    {
        //protected override void Seed(EligibilityContext context)
        //{           

        //    if (!context.EligibilityQuestions.Any())
        //    {
        //        var questions = new List<EligibilityQuestion>();

        //        questions.Add(new EligibilityQuestion
        //        {
        //            Title = "Are you >= 18 years old?",
        //            Options = (new EligibilityOption[]
        //            {
        //                new EligibilityOption { Title= "Yes", IsCorrect= true },
        //                new EligibilityOption { Title= "No", IsCorrect= false },
        //            }).ToList()
        //        });

        //        questions.Add(new EligibilityQuestion
        //        {
        //            Title = "Have you ever donated blood before?",
        //            Options = (new EligibilityOption[]
        //            {
        //                new EligibilityOption { Title= "Yes", IsCorrect= true },
        //                new EligibilityOption { Title= "No", IsCorrect= false },
        //            }).ToList()
        //        });

        //        questions.Add(new EligibilityQuestion
        //        {
        //            Title = "Did you ever have Cancer?",
        //            Options = (new EligibilityOption[]
        //            {
        //                new EligibilityOption { Title= "Yes", IsCorrect= false },
        //                new EligibilityOption { Title= "No", IsCorrect= true },
        //            }).ToList()
        //        });                

        //        context.EligibilityQuestions.AddRange(questions);

        //        context.SaveChanges();
        //    }
        //}
    }
}

