namespace BooksWorld.Application.Commands.BookCommands.Update;

public sealed record UpdateBookRequest
(
    int Id,
    string ImageUrl,
    string Title,
    string Description,
    int AuthorId,
    int GenreId
);
