using MediatR;

namespace BooksWorld.Application.Commands.BookCommands.Create;

public sealed record CreateBookCommand
(
    string ImageUrl,
    string Title,
    string Description,
    int AuthorId,
    int GenreId
) : IRequest;
