namespace BooksWorld.Application.Commands.GenreCommands.Update;

public sealed record UpdateGenreRequest
(
    int Id,
    string Name,
    int? BaseId
);
