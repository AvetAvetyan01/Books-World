using MediatR;

namespace BooksWorld.Application.Commands.AudiobookCommands.Delete;

public sealed record DeleteAudiobookCommand(int Id) : IRequest;
