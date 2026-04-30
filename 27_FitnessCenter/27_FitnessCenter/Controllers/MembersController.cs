using _27_FitnessCenter.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FitnessCenter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly FitnessContext _context;

    public MembersController(FitnessContext context)
    {
        _context = context;
    }

    // --- STANDARD ENDPUNKTE ---

    // GET: api/Members
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
    {
        return await _context.Members.ToListAsync();
    }

    // POST: api/Members (Das ist der Schritt, den du zum Erstellen brauchst!)
    [HttpPost]
    public async Task<ActionResult<Member>> PostMember(Member member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMembers), new { id = member.Id }, member);
    }

    // --- SPEZIELLE LOGIK LAUT ANGABE ---

    // GET: /api/Members/{memberId}/bookings (Alle Buchungen eines Members anzeigen) 
    [HttpGet("{memberId}/bookings")]
    public async Task<ActionResult<Member>> GetMemberBookings(int memberId)
    {
        var member = await _context.Members
            .Include(m => m.Bookings)
            .FirstOrDefaultAsync(m => m.Id == memberId);

        if (member == null) return NotFound();
        return member;
    }

    // POST: /api/Members/{memberId}/bookings/{courseId} (Kurs buchen) 
    [HttpPost("{memberId}/bookings/{courseId}")]
    public async Task<IActionResult> PostBooking(int memberId, int courseId)
    {
        var member = await _context.Members.Include(m => m.Bookings).FirstOrDefaultAsync(m => m.Id == memberId);
        var course = await _context.Courses.Include(c => c.Bookings).FirstOrDefaultAsync(c => c.Id == courseId);

        if (member == null || course == null) return NotFound("Mitglied oder Kurs nicht gefunden.");

        if (member.Bookings.Any(b => b.CourseId == courseId))
        {
            return BadRequest("Course is already booked for member."); 
        }

        if (course.Bookings.Count >= course.MaxParticipants)
        {
            return BadRequest("Course is full."); 
        }

        var booking = new Booking
        {
            MemberId = memberId,
            CourseId = courseId,
            CreatedAt = DateTime.Now 
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMemberBookings), new { memberId = member.Id }, member);
    }
}