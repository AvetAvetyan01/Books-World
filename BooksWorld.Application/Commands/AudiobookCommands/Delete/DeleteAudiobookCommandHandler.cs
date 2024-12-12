using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.AudiobookCommands.Delete;

public class DeleteAudiobookCommandHandler : IRequestHandler<DeleteAudiobookCommand>
{
    private readonly IAudiobookRepository _audiobookRepository;
    public DeleteAudiobookCommandHandler(IAudiobookRepository audiobookRepository)
    {
        _audiobookRepository = audiobookRepository;
    }

    public async Task Handle(DeleteAudiobookCommand command, CancellationToken cancellationToken)
    {
        var audiobook = await _audiobookRepository.GetByIdAsync(command.Id);

        await _audiobookRepository.DeleteAsync(audiobook);
    }
}
