using MediatR;

namespace BooksWorld.Application.Commands.AuthorCommands.Create;

public sealed record CreateAuthorCommand
(
    string FullName,
    string ImageUrl,
    string Autobiographical
) : IRequest;
