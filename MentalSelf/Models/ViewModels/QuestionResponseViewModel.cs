using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models.ViewModels
{
    public class QuestionResponseViewModel
    {
    public Question Question { get; set; }

    public Response Response { get; set; }

    public QuestionType QuestionType { get; set; }

    public UserTest UserTest { get; set; }

    }
}
