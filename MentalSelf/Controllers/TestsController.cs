using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalSelf.Data;
using MentalSelf.Models;
using MentalSelf.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace MentalSelf.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        // Create variable to represent database
        private readonly ApplicationDbContext _context;

        // Create variable to represent User Data
        private readonly UserManager<ApplicationUser> _userManager;

        // Create component to get current user from the _userManager variable
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // Pass in arguments from private varaibles to be used publicly
        public TestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> TestList()
        {
            // Return list of Tests from database to the view
            return View(await _context.Test.ToListAsync());
        }

        // GET: Tests
        public async Task<IActionResult> Index(int Id)
        {


            // Create a list of Responses that include UserResponses, Questions, and UserTestIds
            List<Response> responses = await _context.Response
                                    .Include(r => r.UserResponse)
                                    .Include(r => r.Question)
                                    .Include(r => r.UserTest)
                                    .Where(r => r.Question.TestId == Id)
                                    .ToListAsync();

            // Create a list of QuestionTypes
            List<QuestionType> QuestionTypes = await _context.QuestionType.ToListAsync();

            // Create a list of UserTests that include the Test Data
            List<UserTest> userTests = await _context.UserTest
            .Include(ut => ut.Test)
            .Where(ut => ut.TestId == Id)
            .ToListAsync();

            // Create instance of ResponseDataViewModel
            List<ResponseDataViewModel> responseData = new List<ResponseDataViewModel>();

            // Loop over all question types in the QuestionTypes list
            foreach (QuestionType qt in QuestionTypes)
            {
                // Create a new instance of response data view model
                ResponseDataViewModel rd = new ResponseDataViewModel();
                // Give QuestionType in view model instance the value Type from the QuestionTypes list being looped over
                rd.QuestionType = qt.Type;
                // Create a variable containing a list of responses
                // where the QuestionTypeId associated with the question on the response
                // equals the QuestionTypeId on the list of QuestionTypes being looped over
                var totalResponses = responses.Where(r => r.Question.QuestionTypeId == qt.QuestionTypeId);
                // Create a new integer variable named number
                int number = new int();
                // Loop over list of responses held in totalResposnes variable
                foreach (var r in totalResponses)
                {
                    // Add a UserResponseId value to the number variable for each interation of the loop
                    number += r.UserResponseId;
                }
                // Divide the number variable by the amount of totalResponses and subtract 1
                if (totalResponses.Count() != 0)
                {
                    number = (number / totalResponses.Count()) - 1;
                }
                else
                {
                    number = 0;
                }
                // Set the NumberOfResponses variable in the view model to the value of the number variable
                rd.NumberOfResponses = number;
                // Add the instance of the view model to the list of responseData view models
                responseData.Add(rd);
            }

            

            // Create instance of IndexChartViewModel
            IndexChartViewModel viewModel = new IndexChartViewModel();
            // Add values to the view model based on variables above
            viewModel.UserTest = userTests;
            viewModel.Responses = responses;
            viewModel.QuestionTypes = QuestionTypes;
            viewModel.ResponseData = responseData;

            // Create a list of data points
            List<DataPoint> dataPoints = new List<DataPoint>();
            // Loop over each instance of a view model in the responseData view model list
            foreach (var rd in responseData)
            {
                // Add a new datapoint for each iteration
                // passing in the values of the QuestionType and NumberOfResponses from the view model 
                dataPoints.Add(new DataPoint(rd.QuestionType, rd.NumberOfResponses));
            }

            // Magic
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            // Return the viewModel as the view
            return View(viewModel);
        }

        // GET: Tests/Details/5
        // Pass in an integer that can be null to represent an Id
        public async Task<IActionResult> Details(int? Id)
        {
            // If no Id integer is returned throw a 404 error message
            if (Id == null)
            {
                return NotFound();
            }

            // Create variable for all UserTests in database
            var UserTestDisplay = await _context.UserTest
                .Include(ut => ut.Test)
            // Select only the UserTests whose Id equals the Id integer passed into the view
                .FirstOrDefaultAsync(ut => ut.UserTestId == Id);

            // If no UserTests are returned with a UserTestId that equals the Id integer return 404 error
            if (UserTestDisplay == null)
            {
                return NotFound();
            }

            // Create a list of Responses that include UserResponses and Questions
            // Where the UserTestId associated with the responses
            // Equals the UserTestId associated with the UserTestDisplay variable
            List<Response> responses = await _context.Response
                        .Include(r => r.UserResponse)
                        .Include(r => r.Question)
                        .Where(r => r.UserTestId == UserTestDisplay.UserTestId)
                        .ToListAsync();

            var Questions = _context.Question;

            // Create a list of QuestionTypes with value of QuestionType in database
            List<QuestionType> QuestionTypes = await _context.QuestionType.ToListAsync();

            // Create a new list of ResponseDataViewModels
            List<ResponseDataViewModel> responseData = new List<ResponseDataViewModel>();

            // Loop over all question types in the QuestionTypes list
            foreach (QuestionType qt in QuestionTypes)
            {
                // Create a new instance of response data view model
                ResponseDataViewModel rd = new ResponseDataViewModel();
                // Give QuestionType in view model instance the value Type from the QuestionTypes list being looped over
                rd.QuestionType = qt.Type;
                // Create a variable containing a list of responses
                // where the QuestionTypeId associated with the question on the response
                // equals the QuestionTypeId on the list of QuestionTypes being looped over
                var totalResponses = responses.Where(r => r.Question.QuestionTypeId == qt.QuestionTypeId);
                // Create a new integer variable named number
                int number = new int();
                // Loop over list of responses held in totalResposnes variable
                foreach (var r in totalResponses)
                {
                    // Add a UserResponseId value to the number variable for each interation of the loop
                    number += r.UserResponseId;
                }
                // Divide the number variable by the amount of totalResponses and subtract 1
                if (totalResponses.Count() != 0)
                {
                    number = (number / totalResponses.Count()) - 1;
                } else {
                    number = 0;
                }
                // Set the NumberOfResponses variable in the view model to the value of the number variable
                rd.NumberOfResponses = number;
                // Add the instance of the view model to the list of responseData view models
                responseData.Add(rd);
            }

            // Create new instance of TestDetailsViewModel
            TestDetailsViewModel TestDetails = new TestDetailsViewModel();

            // Add values to the view model based on variables above
            TestDetails.UserTest = UserTestDisplay;
            TestDetails.QuestionTypes = QuestionTypes;            
            TestDetails.Responses = responses;
            TestDetails.ResponseData = responseData;

            // Create a new list of datapoints
            List<DataPoint> dataPoints = new List<DataPoint>();
            // Loop over each instance of a view model in the responseData view model list
            foreach (var rd in responseData)
            {
                // Add a new datapoint for each iteration
                // passing in the values of the QuestionType and NumberOfResponses from the view model 
                dataPoints.Add(new DataPoint(rd.QuestionType, rd.NumberOfResponses));
            }

            // Magic
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            // Return TestDetails to the View
            return View(TestDetails);
        }

        // GET: Tests/Create
        public async Task<IActionResult> Create(int Id)
        {
            // Create instance of a test based on Id passed into create method
            Test test = await _context.Test.FirstOrDefaultAsync(t => t.TestId == Id);
            // Create list of questions with value of Questions in database where Question.TestId equals test.TestId
            List<Question> questions = await _context.Question.Where(q => q.TestId == test.TestId).ToListAsync();

            // Create instance of QuestionResponseViewModel
            QuestionResponseViewModel viewModel = new QuestionResponseViewModel();
            // Give the value of the created list of questions to the Questions List in the view model
            viewModel.Questions = questions;
            
            // return view model
            return View(viewModel);
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Pass in view model and integer to create method
        public async Task<IActionResult> Create(QuestionResponseViewModel viewModel, int Id)
        {
            // Create iterator based on the number of Responses in view model
            for (var i = 0; i < viewModel.Responses.Count; i++) {
            // Remove User and UserId from iterated Responses
                ModelState.Remove($"Responses[{i}].User");
                ModelState.Remove($"Responses[{i}].UserId");
            }

            // Create instance of a test based on Id passed into create method
            Test test = await _context.Test.FirstOrDefaultAsync(t => t.TestId == Id);

            // Create new instance of a UserTest called NewUserTest 
            var NewUserTest = new UserTest()
            { 
                // Provide NewUserTest with necessary values
                TestId = test.TestId
            };

            // Add NewUserTest to UserTests in database
            _context.Add(NewUserTest);

            // Check if model state is valid
            if (ModelState.IsValid)
            {
                // Create iterator based on number of Responses in view model
                for (var i = 0; i < viewModel.Responses.Count; i++)
                {
                    // Give the value of NewUserTest to every instance of UserTest within the list of Responses in the view model
                    viewModel.Responses[i].UserTest = NewUserTest;
                    // Give the value of current user to every instance of User within the list of Responses in the view model
                    viewModel.Responses[i].User = await GetCurrentUserAsync();
                    // Add the iterated list of Responses to the database
                    _context.Add(viewModel.Responses[i]);
                }
                // Save changes to the database
                await _context.SaveChangesAsync();
                // Redirect to Details view with id value of UserTestId in the NewUserTest 
                return RedirectToAction(nameof(Details), new { id = NewUserTest.UserTestId});
            }

            // Return view model
            return View(viewModel);
        }

        // GET: Tests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestID,Title")] Test test)
        {
            if (id != test.TestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTestExists(test.TestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        // GET: Tests/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
                // If Id holds no value throw 404 error
            if (Id == null)
            {
                return NotFound();
            }

            // Create variable for all UserTests in database
            var UserTestDelete = await _context.UserTest
            // Include the Test property
                .Include(ut => ut.Test)
            // Select only the UserTests whose Id equals the Id integer passed into the view
                .FirstOrDefaultAsync(ut => ut.UserTestId == Id);

                // If UserTestDelete holds no value throw 404 error
            if (UserTestDelete == null)
            {
                return NotFound();
            }

            // return UserTestDelete to the view
            return View(UserTestDelete);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            // Create a variable for UserTest in database
            // Find UserTest by Id passed into view
            var userTest = await _context.UserTest.FindAsync(Id);
            // Create a variable of Response in the database
                var responses = await _context.Response
                // Where the UserTestId associated with the response equals the UserTestId associated with the userTest variable
                .Where(r => r.UserTestId == userTest.UserTestId)
                // make the variable an asynchronous list
                .ToListAsync();
            // Loop over all Response instances in the list resposnes
            foreach (Response response in responses){
                // Remove the Response instances
                _context.Remove(response);
            }
            // Remove the UserTest associated with userTest variable
            _context.UserTest.Remove(userTest);
            // Save changes
            await _context.SaveChangesAsync();
            // Redirect to Index
            return RedirectToAction(nameof(Index));
        }

        private bool UserTestExists(int Id)
        {
            return _context.UserTest.Any(ut => ut.UserTestId == Id);
        }
    }
}
