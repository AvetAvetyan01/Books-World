using MediatR;

namespace BooksWorld.Application.Commands.ReviewCommands.Delete;

public sealed record DeleteReviewCommand(int Id) : IRequest;
