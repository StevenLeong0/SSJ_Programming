using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SLLearning.Models;

namespace SLLearning.Controllers
{
    public class EnrolmentController : Controller
    {

        private readonly AppDbContext _context;
        public EnrolmentController(AppDbContext context)
        {
            _context = context;
        }







        public IActionResult Index()
        {
            return View();
        }





        [HttpGet]
        public IActionResult EnrolButton()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EnrolButton(Enrolment enrolment)
        {               

            enrolment.IsEnrolled = true;
            _context.Enrolments.Add(enrolment);
            _context.SaveChanges();         

            return View("Thanks", enrolment);
        }


/*        public IActionResult Thanks(int enrolmentId)
        {
            
            var enrolment = _context.Enrolments
                             .Include(e => e.Member)  
                             .FirstOrDefault(e => e.Id == enrolmentId);

            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);  
        }
*/




        public ViewResult ListResponses()
        {    
            
            var enrolment = _context.Enrolments
            .Include(e => e.Member)
            .ToList();
             return View(enrolment);

        }








        public IActionResult AddMockData()
        {
            // Only add if no members/lessons exist
            if (!_context.Members.Any() && !_context.Lessons.Any())
            {
                var member1 = new Member { FirstName = "Alice", LastName = "Johnson" };
                var member2 = new Member { FirstName = "Bob", LastName = "Smith" };
                _context.Members.AddRange(member1, member2);
                _context.SaveChanges();

                var lesson1 = new Lesson { Title = "Math 101", LessonStatus = LessonStatus.cancelled };
                var lesson2 = new Lesson { Title = "Science Basics", LessonStatus = LessonStatus.closed };
                _context.Lessons.AddRange(lesson1, lesson2);
                _context.SaveChanges();
            }

            return Content("Mock data added.");
        }

    }

}