using Bogus;
using BooksWorld.Domain.Common.DataGenerators;
using BooksWorld.Domain.Common.Enums;
using BooksWorld.Domain.Models;
using BooksWorld.Domain.Models.Book;
using BooksWorld.Persistance.DataProviders.PostgreSql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksWorld.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FakeDataController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;
    private readonly Faker _faker = new();

    [HttpPost("add-genres")]
    public async Task<IResult> AddGenres()
    {
        int level_1 = 25;
        int level_2 = 120;
        int level_3 = 300;

        for (int i = 0; i < level_1; i++)
            await AddGenre(Generator.GenerateGenre(null));

        for (int i = 0; i < level_2; i++)
            await AddGenre(Generator.GenerateGenre(_faker.Random.Int(1, level_1)));
        
        for (int i = 0; i < level_3; i++)
            await AddGenre(Generator.GenerateGenre(_faker.Random.Int(level_1 + 1, level_2)));
        
        await _context.SaveChangesAsync();

        return Results.Ok("Genres added successfully");
    }

    [HttpPost("add-authors")]
    public async Task<IResult> AddAuthors()
    {
        for (int i = 0; i < 100; i++) await 
            _context.Authors.AddAsync(Generator.GenerateAuthor);

        await _context.SaveChangesAsync();

        return Results.Ok("Authors added successfully");
    }


    [HttpPost("add-discounts")]
    public async Task<IResult> AddDiscounts()
    {
        var discounts = new List<Discount>() {
            new() { Percent = 10, Deadline = new DateTime(2024,11,5,11,11,11,DateTimeKind.Utc) },
            new() { Percent = 20, Deadline = new DateTime(2024,12,7,11,11,11,DateTimeKind.Utc) },
            new() { Percent = 30, Deadline = new DateTime(2024,8,21,11,11,11,DateTimeKind.Utc) }};

        await _context.Discounts.AddRangeAsync(discounts);

        await _context.SaveChangesAsync();

        return Results.Ok("Discounts added successfully");
    }

    [HttpPost("add-books")]
    public async Task<IResult> AddBooks()
    {
        for (int i = 0; i < 500; i++)
        {
            var book = Generator.GenerateBook;
            var author = _faker.PickRandom<Author>(_context.Authors);
            var genre = _faker.PickRandom<Genre>(_context.Genres);

            if (book is null) return Results.Problem("author is null");
            if (genre is null) return Results.Problem("Genre is null");

            book.Author = author;
            book.Genre = genre;

            if (_faker.Random.Byte(1, 8) >= 4)
                book.Discount = _faker.PickRandom<Discount>(_context.Discounts);

            await _context.Books.AddAsync(book);
        }
        await _context.SaveChangesAsync();
        return Results.Ok("Books added successfully");
    }

    [HttpPost("add-ebooks")]
    public async Task<IResult> AddEBooks()
    {
        for (int i = 1; i < 300; i++)
        {
            var ebook = Generator.GenerateEBook;
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == ebook.BookId);

            if (book is null) return Results.NotFound($"Book not found (eBook ID {ebook.Id}, Book ID {ebook.BookId})");

            if (!book.Languages.HasFlag(ebook.Language)) book.Languages |= ebook.Language;
            if (!book.Formats.HasFlag(BookFormat.Electronic)) book.Formats |= BookFormat.Electronic;
            book.eBooks ??= new List<EBook>();
            book.eBooks.Add(ebook);
        }
        await _context.SaveChangesAsync();
        return Results.Ok("EBooks added successfully");
    }

    [HttpPost("add-audiobooks")]
    public async Task<IResult> AddAudiobooks()
    {
        for (int i = 1; i < 300; i++)
        {
            var audiobook = Generator.GenerateAudiobook;
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == audiobook.BookId);

            if (book is null) return Results.NotFound($"Book not found (Review ID {audiobook.Id}, Book ID {audiobook.BookId})");

            if (!book.Languages.HasFlag(audiobook.Language)) book.Languages |= audiobook.Language;
            if (!book.Formats.HasFlag(BookFormat.Audio)) book.Formats |= BookFormat.Audio;
            book.Audiobooks ??= new List<Audiobook>();
            book.Audiobooks.Add(audiobook);
        }
        await _context.SaveChangesAsync();
        return Results.Ok("Audiobooks added successfully");
    }

    [HttpPost("add-paperbooks")]
    public async Task<IResult> AddPaperbooks()
    {
        for (int i = 1; i < 300; i++)
        {
            var paperbook = Generator.GeneratePaperbook;
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == paperbook.BookId);

            if (book is null) return Results.NotFound($"Book not found (Review ID {paperbook.Id}, Book ID {paperbook.BookId})");

            if (!book.Languages.HasFlag(paperbook.Language)) book.Languages |= paperbook.Language;
            if (!book.Formats.HasFlag(BookFormat.Paper)) book.Formats |= BookFormat.Paper;
            book.Paperbooks ??= new List<Paperbook>();
            book.Paperbooks.Add(paperbook);
        }
        await _context.SaveChangesAsync();
        return Results.Ok("Paperbooks added successfully");
    }

    [HttpPost("add-reviews")]
    public async Task<IResult> AddReviews()
    {
        for (int i = 1; i < 700; i++)
        {
            var review = Generator.GenerateReview;
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == review.BookId);

            if (book is null) return Results.NotFound($"Book not found (Review ID {review.Id}, Book ID {review.BookId})");

            book.Reviews!.Add(review);
        }
        await _context.SaveChangesAsync();
        return Results.Ok("Reviews added successfully");
    }

    [HttpPost("add-genre")]
    private async Task AddGenre(Genre genre)
    {
        if (ModelState.IsValid)
        {
            if (genre.BaseGenreId != null && genre.BaseGenreId != 0)
            {
                var baseCategory = _context.Genres.FirstOrDefault(c => c.Id == genre.BaseGenreId);

                genre.SubgenresCount = genre.Subgenres.Count;
                baseCategory!.SubgenresCount++;
                baseCategory.Subgenres.Add(genre);
            }
            else
                await _context.Genres.AddAsync(genre);

            await _context.SaveChangesAsync();
        }
    }
}