using System;
using System.CodeDom;
using System.Data.Entity;
using LifeLine.Core;
using LifeLine.Core.Models;
using System.Linq;
using System.Collections.Generic;

namespace LifeLine.Infrastructure
{
    /// <summary>
    /// DB Intializer withDrop create Db when model change approach
    /// </summary>

    public class BloodDonorInitalizeDb : CreateDatabaseIfNotExists<BloodDonorContext>
    {
        /// <summary>
        /// Seed to insert some sample/test record into the db when the application runs/creates the db for the first time
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(BloodDonorContext context)
        {
            //Default Camp entries
            if (!context.Camps.Any())
            {
                var camps = new List<Camp>();

                camps.Add(new Camp
                {
                    Id = new Guid("A176872A-BD7E-49F1-A4AE-D66947421CE9"),
                    Name = "SM Blood Drive",
                    Where = "Santa Monica",
                    When = "01/14/2016"
                });

                camps.Add(new Camp
                {
                    Id = new Guid("56E72E4B-1D70-4844-9CA3-0930F3073A9B"),
                    Name = "Culver City Blood Drive",
                    Where = "Culver City",
                    When = "01/20/2016"
                });

                camps.Add(new Camp
                {
                    Id = new Guid("D44874AE-68F6-4D15-BEB4-ECCB82A7BE99"),
                    Name = "LA Blood Drive",
                    Where = "Pasadena",
                    When = "01/25/2016"
                });

                context.Camps.AddRange(camps);

                context.SaveChanges();
            }

            //Default Donor entries
            if (!context.Persons.Any())
            {
                var donors = new List<Donor>();

                donors.Add(new Donor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Smith",
                    PhoneNumber = "333333333",
                    DonationDate = "01/14/2016",
                    CampId = new Guid("A176872A-BD7E-49F1-A4AE-D66947421CE9")
                });
                donors.Add(new Donor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Black",
                    LastName = "Smith",
                    PhoneNumber = "444444444",
                    DonationDate = "01/20/2016",
                    CampId = new Guid("56E72E4B-1D70-4844-9CA3-0930F3073A9B")
                });

                context.Persons.AddRange(donors);

                context.SaveChanges();

            }

            if (!context.EligibilityQuestions.Any())
            {
                var questions = new List<EligibilityQuestion>();

                questions.Add(new EligibilityQuestion
                {
                    Title = "Are you >= 18 years old?",
                    Options = (new EligibilityOption[]
                    {
                        new EligibilityOption { Title= "Yes", IsCorrect= true },
                        new EligibilityOption { Title= "No", IsCorrect= false },
                    }).ToList()
                });

                questions.Add(new EligibilityQuestion
                {
                    Title = "Have you ever donated blood before?",
                    Options = (new EligibilityOption[]
                    {
                        new EligibilityOption { Title= "Yes", IsCorrect= true },
                        new EligibilityOption { Title= "No", IsCorrect= false },
                    }).ToList()
                });

                questions.Add(new EligibilityQuestion
                {
                    Title = "Did you ever have Cancer?",
                    Options = (new EligibilityOption[]
                    {
                        new EligibilityOption { Title= "Yes", IsCorrect= false },
                        new EligibilityOption { Title= "No", IsCorrect= true },
                    }).ToList()
                });

                context.EligibilityQuestions.AddRange(questions);

                context.SaveChanges();
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
