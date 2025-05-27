using Microsoft.AspNetCore.Mvc;
using SeniorLearn.Data;

namespace SeniorLearn.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var members = _context.Members;
            return View(members);
        }
    }
}
