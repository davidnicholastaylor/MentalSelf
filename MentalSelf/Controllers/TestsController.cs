﻿using System;
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

        // Create public constructor for private variables to be used publicly
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
            var currentUser = await GetCurrentUserAsync();

            // Create a list of Responses that include UserResponses, UserTests, User and Questions that include their QuestionTypes
            // where the TestId of the Questions equal the Id passed in from the TestList view
            List<Response> responses = await _context.Response
                                    .Include(r => r.Rating)
                                    .Include(r => r.UserTest)
                                    .ThenInclude(ut => ut.User)
                                    .Include(r => r.Question)
                                    .ThenInclude(q => q.QuestionType)
                                    .Where(r => r.Question.TestId == Id && r.UserTest.User == currentUser)
                                    .ToListAsync();

            


            // Create a list of QuestionTypes
            // Select the QuestionTypes available through the Questions on the responses
            // Make the selected QuestionTypes distinct so they don't repeat
            // Order QuestionTypes by QuestionTypeId
            List<QuestionType> questionTypes = responses.Select(r => r.Question.QuestionType).Distinct().OrderBy(qt => qt.QuestionTypeId).ToList();

            // Create a list of UserTests that include the Test Data
            List<UserTest> userTests = await _context.UserTest
            .Include(ut => ut.Test)
            .Where(ut => ut.TestId == Id && ut.User == currentUser)
            .ToListAsync();

            // Create instance of ResponseDataViewModel
            List<ResponseDataViewModel> responseData = new List<ResponseDataViewModel>();

            // Loop over all question types in the QuestionTypes list
            foreach (QuestionType qt in questionTypes)
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
                double number = new double();
                // Loop over list of responses held in totalResposnes variable
                foreach (var r in totalResponses)
                {
                    // Add a UserResponseId value to the number variable for each interation of the loop
                    number += r.Rating.RatingAmount;
                }
                // Divide the number variable by the amount of totalResponses and subtract 1
                number = (number / totalResponses.Count());

                number = Math.Round(number, 2);
                
                // Set the NumberOfResponses variable in the view model to the value of the number variable
                rd.NumberOfResponses = number;
                // Add the instance of the view model to the list of responseData view models
                responseData.Add(rd);
            }

            Test test = await _context.Test.FirstOrDefaultAsync(t => t.TestId == Id);

            // Create instance of IndexChartViewModel
            IndexChartViewModel viewModel = new IndexChartViewModel();
            // Add values to the view model based on variables above

            viewModel.Test = test;
            viewModel.UserTest = userTests;
            viewModel.Responses = responses;
            viewModel.QuestionTypes = questionTypes;
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

            var currentUser = await GetCurrentUserAsync();

            // Create a list of Responses that include UserResponses and Questions that include their QuestionTypes
            // Where the UserTestId associated with the responses
            // Equals the UserTestId associated with the UserTestDisplay variable
            List<Response> responses = await _context.Response
                        .Include(r => r.Rating)
                        .Include(r => r.UserTest)
                        .ThenInclude(ut => ut.User)
                        .Include(r => r.Question)
                        .ThenInclude(q => q.QuestionType)
                        .Where(r => r.UserTestId == UserTestDisplay.UserTestId && r.UserTest.User == currentUser)
                        .OrderBy(r => r.Question.QuestionId)
                        .ToListAsync();


            // Create a list of QuestionTypes
            // Select the QuestionTypes available through the Questions on the responses
            // Make the selected QuestionTypes distinct so they don't repeat
            // Order QuestionTypes by QuestionTypeId
            List<QuestionType> QuestionTypes = responses.Select(r => r.Question.QuestionType).Distinct().ToList();

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
                double number = new double();
                // Loop over list of responses held in totalResposnes variable
                foreach (var r in totalResponses)
                {
                    // Add a UserResponseId value to the number variable for each interation of the loop
                    number += r.Rating.RatingAmount;
                }
                // Divide the number variable by the amount of totalResponses and subtract 1
                number = (number / totalResponses.Count());

                number = Math.Round(number, 2);

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
            // Give the value of "questions" to the Questions list in the view model
            viewModel.Questions = questions;
            // Give the value of "test" to the Test instance in the view model
            viewModel.Test = test;
            
            // return the view model
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
            // Create instance of a test based on Id passed into create method
            Test test = await _context.Test.FirstOrDefaultAsync(t => t.TestId == Id);

            var currentUser = await GetCurrentUserAsync();

            // Create new instance of a UserTest called NewUserTest 
            var NewUserTest = new UserTest()
            {
                // Provide NewUserTest with necessary values
                TestId = test.TestId,
                UserId = currentUser.Id
            };

            // Add NewUserTest to UserTests in database
            _context.Add(NewUserTest);

            ModelState.Remove($"UserTest.User");
            ModelState.Remove($"UserTest.UserId");

            // Check if model state is valid
            if (ModelState.IsValid)
            {
                // Create iterator based on number of Responses in view model
                for (var i = 0; i < viewModel.Responses.Count; i++)
                {
                    // Give the value of NewUserTest to every instance of UserTest within the list of Responses in the view model
                    viewModel.Responses[i].UserTest = NewUserTest;
                    // Give the value of current user to every instance of User within the list of Responses in the view model
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
                .Include(ut => ut.User)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            // Create a variable for UserTest in database
            // Find UserTest by Id passed into view
            var userTest = await _context.UserTest.FindAsync(Id);
            // Create a variable of Response in the database
                // Where the UserTestId associated with the response equals the UserTestId associated with the userTest variable
                // make the variable an asynchronous list
                var responses = await _context.Response
                .Where(r => r.UserTestId == userTest.UserTestId)
                .ToListAsync();
            var testId = userTest.TestId;
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
            return RedirectToAction("Index", "Tests", new { id = testId });
        }

        private bool UserTestExists(int Id)
        {
            return _context.UserTest.Any(ut => ut.UserTestId == Id);
        }
    }
}
