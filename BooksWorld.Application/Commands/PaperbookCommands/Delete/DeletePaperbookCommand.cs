using MediatR;

namespace BooksWorld.Application.Commands.PaperbookCommands.Delete;

public record DeletePaperbookCommand(int Id) : IRequest;
