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
        public async Task<IActionResult> Index()
        {
            // Return list of UserTests from database to the view
            return View(await _context.UserTest.ToListAsync());
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
            // Select only the UserTests whose Id equals the Id integer passed into the view
                .FirstOrDefaultAsync(m => m.UserTestId == Id);

            // If no UserTests are returned with a UserTestId that equals the Id integer return 404 error
            if (UserTestDisplay == null)
            {
                return NotFound();
            }

            List<Response> responses = await _context.Response
                        .Include(r => r.UserResponse)
                        .Include(r => r.Question)
                        .Where(r => r.UserTestId == UserTestDisplay.UserTestId)
                        .ToListAsync();

            // Create a list of QuestionTypes with value of QuestionType in database
            List<QuestionType> QuestionTypes = await _context.QuestionType.ToListAsync();

            // Create new instance of TestDetailsViewModel
            TestDetailsViewModel TestDetails = new TestDetailsViewModel();

            // Pass value of UserTestDisplay into UserTest variable in view model
            TestDetails.UserTest = UserTestDisplay;

            TestDetails.QuestionTypes = QuestionTypes;
            
            TestDetails.Responses = responses;

            //// Create a new list of datapoints
            //List<DataPoint> dataPoints = new List<DataPoint>();

            //// Add data to list of datapoints
            //dataPoints.Add(new DataPoint("USA", 121));
            //dataPoints.Add(new DataPoint("Great Britain", 67));
            //dataPoints.Add(new DataPoint("China", 70));
            //dataPoints.Add(new DataPoint("Russia", 56));
            //dataPoints.Add(new DataPoint("Germany", 42));
            //dataPoints.Add(new DataPoint("Japan", 41));
            //dataPoints.Add(new DataPoint("France", 42));
            //dataPoints.Add(new DataPoint("South Korea", 21));

            //// Magic
            //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

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
                    if (!TestExists(test.TestId))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test
                .FirstOrDefaultAsync(m => m.TestId == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var test = await _context.Test.FindAsync(id);
            _context.Test.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.TestId == id);
        }
    }
}
