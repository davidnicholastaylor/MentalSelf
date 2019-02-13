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
        public List<Rating> Ratings { get; set; }

        public List<ResponseDataViewModel> ResponseData { get; set; } 
    }

    [DataContract]
    public class DataPoint
    {
        // Create instance of data points with a string for label and a double for y axis
        public DataPoint(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}