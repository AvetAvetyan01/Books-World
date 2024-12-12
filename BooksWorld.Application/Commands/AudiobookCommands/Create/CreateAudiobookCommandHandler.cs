using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.AudiobookCommands.Create;

public class CreateAudiobookCommandHandler : IRequestHandler<CreateAudiobookCommand, Audiobook>
{
    private readonly IMapper _mapper;
    private readonly IAudiobookRepository _audiobookRepository;
    public CreateAudiobookCommandHandler(IAudiobookRepository audiobookRepository,IMapper mapper)
    {
        _audiobookRepository = audiobookRepository;
        _mapper = mapper;
    }

    public async Task<Audiobook> Handle(CreateAudiobookCommand command, CancellationToken cancellationToken)
    {
        var audiobook = _mapper.Map<Audiobook>(command);

        await _audiobookRepository.CreateAsync(audiobook);

        return audiobook;
    }
}