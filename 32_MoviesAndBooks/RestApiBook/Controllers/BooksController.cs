// NEU (Aufgabe 1c): BooksController – alle CRUD-Operationen für Bücher
// Wird normalerweise per Scaffolding in VS generiert:
// Rechtsklick Controllers → Add → New Scaffolded Item →
// API Controller with actions, using Entity Framework
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiBook.Data;
using RestApiBook.Models;

namespace RestApiBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;

        public BooksController(BookContext context) { _context = context; }

        // GET /books – alle Bücher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
            => await _context.Books.ToListAsync();

        // GET /books/5 – ein Buch nach Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book == null ? NotFound() : book;
        }

        // POST /books – neues Buch erstellen
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT /books/5 – Buch aktualisieren
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            _context.Entry(book).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(e => e.Id == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE /books/5 – Buch löschen
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
