using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models.ViewModels
{
    public class QuestionResponseViewModel
    {
    public UserTest UserTest { get; set; } = new UserTest { };
    public Test Test { get; set; }
    public List<Question> Questions { get; set; }
    public List<Response> Responses { get; set; }
    public List<Rating> Ratings { get; set; }

    // Create instance of QuestionResponseViewModel
        public QuestionResponseViewModel()
        {
            // Create new list of User Responses to be used in view
            Ratings = new List<Rating> {
            new Rating {
                RatingId = 1,
                RatingAmount = 0,
                RatingDescription = "Not at all"
            },
            new Rating {
                RatingId = 2,
                RatingAmount = 1,
                RatingDescription = "Rare, less than a couple days"
            },
            new Rating {
                RatingId = 3,
                RatingAmount = 2,
                RatingDescription = "Several days"
            },
            new Rating {
                RatingId = 4,
                RatingAmount = 3,
                RatingDescription = "More than half the days"
            },
            new Rating {
                RatingId = 5,
                RatingAmount = 4,
                RatingDescription = "Nearly every day"
            },
            };
        }
    }
}
