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
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public TestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> TestList()
        {
            return View(await _context.Tests.ToListAsync());
        }

        // GET: Tests
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserTests.ToListAsync());
        }

        // GET: Tests/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var UserTestDisplay = await _context.UserTests
                .FirstOrDefaultAsync(m => m.UserTestId == Id);
            if (UserTestDisplay == null)
            {
                return NotFound();
            }

            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("USA", 121));
            dataPoints.Add(new DataPoint("Great Britain", 67));
            dataPoints.Add(new DataPoint("China", 70));
            dataPoints.Add(new DataPoint("Russia", 56));
            dataPoints.Add(new DataPoint("Germany", 42));
            dataPoints.Add(new DataPoint("Japan", 41));
            dataPoints.Add(new DataPoint("France", 42));
            dataPoints.Add(new DataPoint("South Korea", 21));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            TestDetailsViewModel TestDetails = new TestDetailsViewModel();
            TestDetails.UserTest = UserTestDisplay;

            return View(TestDetails);
        }

        // GET: Tests/Create
        public async Task<IActionResult> Create(int Id)
        {
            Test test = await _context.Tests.FirstOrDefaultAsync(t => t.TestId == Id);
            List<Question> questions = await _context.Questions.Where(q => q.TestId == test.TestId).ToListAsync();

            QuestionResponseViewModel viewModel = new QuestionResponseViewModel();
            viewModel.Questions = questions;
            
            return View(viewModel);
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionResponseViewModel questionAnswer, int Id)
        {
            for (var i = 0; i < questionAnswer.Responses.Count; i++) {
                ModelState.Remove($"Responses[{i}].User");
                ModelState.Remove($"Responses[{i}].UserId");
            }

            Test test = await _context.Tests.FirstOrDefaultAsync(t => t.TestId == Id);

            var NewUserTest = new UserTest()
            {
                TestId = test.TestId
            };

            _context.Add(NewUserTest);

            if (ModelState.IsValid)
            {
                for (var i = 0; i < questionAnswer.Responses.Count; i++)
                {
                    questionAnswer.Responses[i].UserTest = NewUserTest;
                    questionAnswer.Responses[i].User = await GetCurrentUserAsync();
                    _context.Add(questionAnswer.Responses[i]);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = NewUserTest.UserTestId});
            }

            return View(questionAnswer);
        }

        // GET: Tests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Tests.FindAsync(id);
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

            var test = await _context.Tests
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
            var test = await _context.Tests.FindAsync(id);
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestExists(int id)
        {
            return _context.Tests.Any(e => e.TestId == id);
        }
    }
}
