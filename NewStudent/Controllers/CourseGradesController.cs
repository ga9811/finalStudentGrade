using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewStudent.Data;
using NewStudent.Models;

namespace NewStudent.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CourseGradesController : Controller
    {
        private readonly NewStudentContext _context;

        public CourseGradesController(NewStudentContext context)
        {
            _context = context;
        }

        // GET: CourseGrades
        public async Task<IActionResult> Index()
        {
              return _context.CourseGrade != null ? 
                          View(await _context.CourseGrade.ToListAsync()) :
                          Problem("Entity set 'NewStudentContext.CourseGrade'  is null.");
        }

        // GET: CourseGrades/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CourseGrade == null)
            {
                return NotFound();
            }

            var courseGrade = await _context.CourseGrade
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseGrade == null)
            {
                return NotFound();
            }

            return View(courseGrade);
        }

        // GET: CourseGrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseGrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseTitle,CourseName,Semester,Year,Grade")] CourseGrade courseGrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseGrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseGrade);
        }

        // GET: CourseGrades/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CourseGrade == null)
            {
                return NotFound();
            }

            var courseGrade = await _context.CourseGrade.FindAsync(id);
            if (courseGrade == null)
            {
                return NotFound();
            }
            return View(courseGrade);
        }

        // POST: CourseGrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CourseId,CourseTitle,CourseName,Semester,Year,Grade")] CourseGrade courseGrade)
        {
            if (id != courseGrade.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseGradeExists(courseGrade.CourseId))
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
            return View(courseGrade);
        }

        // GET: CourseGrades/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CourseGrade == null)
            {
                return NotFound();
            }

            var courseGrade = await _context.CourseGrade
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseGrade == null)
            {
                return NotFound();
            }

            return View(courseGrade);
        }

        // POST: CourseGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CourseGrade == null)
            {
                return Problem("Entity set 'NewStudentContext.CourseGrade'  is null.");
            }
            var courseGrade = await _context.CourseGrade.FindAsync(id);
            if (courseGrade != null)
            {
                _context.CourseGrade.Remove(courseGrade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseGradeExists(string id)
        {
          return (_context.CourseGrade?.Any(e => e.CourseId == id)).GetValueOrDefault();
        }
    }
}
