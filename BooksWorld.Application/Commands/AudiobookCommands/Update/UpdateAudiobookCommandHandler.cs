using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.AudiobookCommands.Update;

public class UpdateAudiobookCommandHandler : IRequestHandler<UpdateAudiobookCommand>
{
    private readonly IAudiobookRepository _audiobookRepository;
    public UpdateAudiobookCommandHandler(IAudiobookRepository audiobookRepository)
    {
        _audiobookRepository = audiobookRepository;
    }

#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
    public async Task Handle(UpdateAudiobookCommand command, CancellationToken cancellationToken)
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
    {
        


    }
}
