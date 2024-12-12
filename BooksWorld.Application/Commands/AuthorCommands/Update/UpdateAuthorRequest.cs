namespace BooksWorld.Application.Commands.AuthorCommands.Update;

public sealed record UpdateAuthorRequest 
(
    int Id,
    string FullName,
    string ImageUrl,
    string Autobiographical
);
