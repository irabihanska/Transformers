using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using BusinessLogic.Interfaces;

namespace Libro_Swap.Controllers
{
    public class BooksController : Controller
    {
        private readonly Libro_SwapDBContext _context;
        private readonly IBookService _bookService;

        public BooksController(Libro_SwapDBContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllWithDetails();
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCoverage)
                .Include(b => b.Bookhouse)
                .Include(b => b.City)
                .Include(b => b.CurrentOwner)
                .Include(b => b.Genre)
                .Include(b => b.Language)
                .Include(b => b.SecondaryGenre)
                .Include(b => b.TertiaryGenre)
                .Include(b => b.Translator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName");
            ViewData["BookCoverageId"] = new SelectList(_context.Coverages, "Id", "CoverageName");
            ViewData["BookhouseId"] = new SelectList(_context.Bookhouses, "Id", "BookhouseName");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "CityCode");
            ViewData["CurrentOwnerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "GenreName");
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "LanguageCode");
            ViewData["SecondaryGenreId"] = new SelectList(_context.Genres, "Id", "GenreName");
            ViewData["TertiaryGenreId"] = new SelectList(_context.Genres, "Id", "GenreName");
            ViewData["TranslatorId"] = new SelectList(_context.Authors, "Id", "AuthorName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,CurrentOwnerId,GenreId,SecondaryGenreId,TertiaryGenreId,LanguageId,BookCoverageId,BookhouseId,CityId,AuthorId,TranslatorId,Translation,Pages,Year,Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName", book.AuthorId);
            ViewData["BookCoverageId"] = new SelectList(_context.Coverages, "Id", "CoverageName", book.BookCoverageId);
            ViewData["BookhouseId"] = new SelectList(_context.Bookhouses, "Id", "BookhouseName", book.BookhouseId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "CityCode", book.CityId);
            ViewData["CurrentOwnerId"] = new SelectList(_context.Users, "Id", "Id", book.CurrentOwnerId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.GenreId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "LanguageCode", book.LanguageId);
            ViewData["SecondaryGenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.SecondaryGenreId);
            ViewData["TertiaryGenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.TertiaryGenreId);
            ViewData["TranslatorId"] = new SelectList(_context.Authors, "Id", "AuthorName", book.TranslatorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName", book.AuthorId);
            ViewData["BookCoverageId"] = new SelectList(_context.Coverages, "Id", "CoverageName", book.BookCoverageId);
            ViewData["BookhouseId"] = new SelectList(_context.Bookhouses, "Id", "BookhouseName", book.BookhouseId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "CityCode", book.CityId);
            ViewData["CurrentOwnerId"] = new SelectList(_context.Users, "Id", "Id", book.CurrentOwnerId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.GenreId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "LanguageCode", book.LanguageId);
            ViewData["SecondaryGenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.SecondaryGenreId);
            ViewData["TertiaryGenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.TertiaryGenreId);
            ViewData["TranslatorId"] = new SelectList(_context.Authors, "Id", "AuthorName", book.TranslatorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,CurrentOwnerId,GenreId,SecondaryGenreId,TertiaryGenreId,LanguageId,BookCoverageId,BookhouseId,CityId,AuthorId,TranslatorId,Translation,Pages,Year,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "AuthorName", book.AuthorId);
            ViewData["BookCoverageId"] = new SelectList(_context.Coverages, "Id", "CoverageName", book.BookCoverageId);
            ViewData["BookhouseId"] = new SelectList(_context.Bookhouses, "Id", "BookhouseName", book.BookhouseId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "CityCode", book.CityId);
            ViewData["CurrentOwnerId"] = new SelectList(_context.Users, "Id", "Id", book.CurrentOwnerId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.GenreId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "LanguageCode", book.LanguageId);
            ViewData["SecondaryGenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.SecondaryGenreId);
            ViewData["TertiaryGenreId"] = new SelectList(_context.Genres, "Id", "GenreName", book.TertiaryGenreId);
            ViewData["TranslatorId"] = new SelectList(_context.Authors, "Id", "AuthorName", book.TranslatorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCoverage)
                .Include(b => b.Bookhouse)
                .Include(b => b.City)
                .Include(b => b.CurrentOwner)
                .Include(b => b.Genre)
                .Include(b => b.Language)
                .Include(b => b.SecondaryGenre)
                .Include(b => b.TertiaryGenre)
                .Include(b => b.Translator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
