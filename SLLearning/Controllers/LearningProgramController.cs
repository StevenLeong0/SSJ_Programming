using Microsoft.AspNetCore.Mvc;
using SLLearning.Models;

namespace SLLearning.Controllers
{
    public class LearningProgramController : Controller
    {

        private readonly AppDbContext _context;

        // Dependency Injection of the DbContext
        public LearningProgramController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult ProgramDetails(int Id)
        {

            var programDetails = LearningProgram.GetProgramDetails(Id);

            return View(programDetails);  // Pass data to the view
        }

        public IActionResult GetProgramByMember(int MemberId)
        {
            var programDetails = LearningProgram.GetProgramByMember(MemberId);
            return View(programDetails);
            
        }

        public IActionResult GetProgramByCategory (int CategoryId)
        {
            var programDetails = LearningProgram.GetProgramByCategory(CategoryId);
            return View(programDetails);
        }





    }
}