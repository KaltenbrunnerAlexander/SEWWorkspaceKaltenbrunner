// NEU HINZUGEFÜGT (Aufgabe 1c): BooksController
// Stellt alle CRUD-Operationen für Bücher bereit.
// Normalerweise würde dieser Controller durch Scaffolding in Visual Studio generiert werden.
// In Visual Studio: Rechtsklick auf Controllers → Add → New Scaffolded Item →
// API Controller with actions, using Entity Framework → Book als Model, BookContext als DbContext wählen.

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
        // AUFGABE 1c: DbContext wird per Dependency Injection injiziert
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        // GET: /books
        // Gibt alle Bücher aus der Datenbank zurück (READ all)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: /books/5
        // Gibt ein einzelnes Buch anhand der Id zurück (READ single)
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            // Suche das Buch in der Datenbank
            var book = await _context.Books.FindAsync(id);

            // Wenn nicht gefunden: 404 Not Found zurückgeben
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST: /books
        // Erstellt ein neues Buch in der Datenbank (CREATE)
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            // Buch zur Datenbank hinzufügen
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            // 201 Created zurückgeben mit dem neu erstellten Buch
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: /books/5
        // Aktualisiert ein bestehendes Buch (UPDATE)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            // Id im Pfad muss mit der Id im Body übereinstimmen
            if (id != book.Id)
            {
                return BadRequest();
            }

            // Buch als geändert markieren
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Wenn das Buch nicht mehr existiert: 404 zurückgeben
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // 204 No Content - Update war erfolgreich, kein Inhalt zurückgeben
            return NoContent();
        }

        // DELETE: /books/5
        // Löscht ein Buch aus der Datenbank (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            // Buch in der Datenbank suchen
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            // Buch aus der Datenbank entfernen
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            // 204 No Content - Löschen war erfolgreich
            return NoContent();
        }

        // Hilfsmethode: Prüft ob ein Buch mit der gegebenen Id existiert
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
