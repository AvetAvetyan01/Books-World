using MediatR;

namespace BooksWorld.Application.Commands.GenreCommands.Update;

public sealed record UpdateGenreCommand
(
    int Id,
    string Name,
    int? BaseId
) : IRequest;
