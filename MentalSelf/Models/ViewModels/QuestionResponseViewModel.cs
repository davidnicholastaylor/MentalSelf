using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models.ViewModels
{
    public class QuestionResponseViewModel
    {
    public UserTest UserTest { get; set; } = new UserTest { };
    public List<Question> Questions { get; set; }
    public List<Response> Responses { get; set; }
    public List<UserResponse> UserResponses { get; set; }

        public QuestionResponseViewModel()
        {
            UserResponses = new List<UserResponse> {
            new UserResponse {
                UserResponseId = 1,
                Rating = "Not at all"
            },
            new UserResponse {
                UserResponseId = 2,
                Rating = "Rare, less than a couple days"
            },
            new UserResponse {
                UserResponseId = 3,
                Rating = "Several days"
            },
            new UserResponse {
                UserResponseId = 4,
                Rating = "More than half the days"
            },
            new UserResponse {
                UserResponseId = 5,
                Rating = "Nearly every day"
            },
            };
        }
    }
}
