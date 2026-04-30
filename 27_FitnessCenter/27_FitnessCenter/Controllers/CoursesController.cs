using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _27_FitnessCenter.Models;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly FitnessContext _context;
    public CoursesController(FitnessContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses() => await _context.Courses.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCourses), new { id = course.Id }, course);
    }
}


        