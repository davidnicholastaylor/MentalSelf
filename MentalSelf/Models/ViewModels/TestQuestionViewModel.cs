using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MentalSelf.Models.ViewModels
{
    public class TestQuestionViewModel
    {
        public UserTest UserTest { get; set; }
        
        public Test Test { get; set; }

        public Response Response { get; set; }

        public QuestionType QuestionType { get; set; }

        public IEnumerable<Question> Question { get; set; }
        
    }

    [DataContract]
    public class DataPoint
    {
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