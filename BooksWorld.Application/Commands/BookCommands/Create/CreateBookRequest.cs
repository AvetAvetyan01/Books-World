namespace BooksWorld.Application.Commands.BookCommands.Create;

public sealed record CreateBookRequest
(
    string ImageUrl,
    string Title,
    string Description,
    int AuthorId,
    int GenreId
);