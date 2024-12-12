using MediatR;

namespace BooksWorld.Application.Commands.EBookCommands.Delete;

public record DeleteEBookCommand(int Id): IRequest;
