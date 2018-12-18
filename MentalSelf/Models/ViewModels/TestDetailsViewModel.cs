using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MentalSelf.Models.ViewModels
{
    public class TestDetailsViewModel
    {
        public UserTest UserTest { get; set; }
        public List<Question> Questions { get; set; }
        public List<QuestionType> QuestionTypes { get; set; }
        public List<Response> Responses { get; set; }
        public List<UserResponse> UserResponses { get; set; }
        
        public TestDetailsViewModel()
        {
            // Create new list of User Responses to be used in view
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

    //[DataContract]
    //public class DataPoint
    //{   
    //    // Create instance of data points with a string for label and a double for y axis
    //    public DataPoint(string label, double y)
    //    {
    //        this.Label = label;
    //        this.Y = y;
    //    }

    //    //Explicitly setting the name to be used while serializing to JSON.
    //    [DataMember(Name = "label")]
    //    public string Label = "";

    //    //Explicitly setting the name to be used while serializing to JSON.
    //    [DataMember(Name = "y")]
    //    public Nullable<double> Y = null;
    //}
}