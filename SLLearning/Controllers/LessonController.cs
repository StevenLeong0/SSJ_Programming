using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SLLearning.Models;

namespace SLLearning.Controllers
{
    public class LessonController : Controller
    {
        private readonly AppDbContext _context;

        public LessonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lesson
        public async Task<IActionResult> Index()
        {


            var lessons = await _context.Lessons.Include(l => l.Enrollments).ToListAsync();
            return View(lessons);
        }

        // GET: Lesson/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lesson/Create
        public IActionResult Create()
        {
            ViewData["LessonStatus"] = new SelectList(Enum.GetValues(typeof(LessonStatus)));
            return View();
        }

        // POST: Lesson/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lesson lesson)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Add(lesson);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Could log ex here
                    ModelState.AddModelError("", "Unable to save changes: " + ex.Message);
                }
            }

                ViewData["LessonStatus"] = new SelectList(Enum.GetValues(typeof(LessonStatus)), lesson.LessonStatus);
                return View(lesson);
            

        }


        // GET: Lesson/Edit/5
        public async Task<IActionResult> Edit(int? id)


        {
           


            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            ViewData["LessonStatus"] = new SelectList(Enum.GetValues(typeof(LessonStatus)), lesson.LessonStatus);
            return View(lesson);
        }

        // POST: Lesson/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(lesson.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes: " + ex.Message);
            }

            ViewData["LessonStatus"] = new SelectList(Enum.GetValues(typeof(LessonStatus)), lesson.LessonStatus);
            return View(lesson);
        }

        // GET: Lesson/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lesson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }


        public IActionResult ChangeStatus()
        {
            var model = new Lesson();

        


            IEnumerable<LessonStatus> statusTypes = Enum.GetValues(typeof(LessonStatus)).Cast<LessonStatus>();
            model.LessonStatusList =

                statusTypes.Select(status => new SelectListItem
                {
                    Text = status.ToString(),
                    Value = ((int)status).ToString()
                });

            return View(model); }
                
                
                
                
           

        [HttpPost]
        public IActionResult ChangeStatus(Lesson updatedlesson)
        {
            if (ModelState.IsValid)
            {


                IEnumerable<LessonStatus> statusTypes = Enum.GetValues(typeof(LessonStatus)).Cast<LessonStatus>();
                updatedlesson.LessonStatusList = statusTypes.Select(status => new SelectListItem
                {
                    Text = status.ToString(),
                    Value = ((int)status).ToString()
                });
                return View(updatedlesson);
            }

                var lesson = _context.Lessons.Find(updatedlesson.Id);
            if (lesson == null)
            {
                {
                    return NotFound();
                }
            }

                    lesson.LessonStatus = updatedlesson.LessonStatus;

                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

               }




            }
        }
    

