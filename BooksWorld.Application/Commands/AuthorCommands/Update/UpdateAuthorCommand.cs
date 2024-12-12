using MediatR;

namespace BooksWorld.Application.Commands.AuthorCommands.Update;

public sealed record UpdateAuthorCommand
(
    int Id,

    string FullName,
    string ImageUrl,
    string Autobiographical
) : IRequest;
