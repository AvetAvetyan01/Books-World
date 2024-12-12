using MediatR;

namespace BooksWorld.Application.Commands.BookCommands.Update;

public sealed record UpdateBookCommand
(
    int Id,

    string ImageUrl,
    string Title,
    string Description,
    int AuthorId,
    int GenreId
) : IRequest;