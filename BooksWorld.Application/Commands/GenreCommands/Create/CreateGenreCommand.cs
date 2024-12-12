using MediatR;

namespace BooksWorld.Application.Commands.GenreCommands.Create;

public sealed record CreateGenreCommand
(
    string Name,
    int? BaseId
) : IRequest;
