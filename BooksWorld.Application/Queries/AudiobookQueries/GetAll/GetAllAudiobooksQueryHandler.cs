using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.AudiobookQueries.GetAll;

public class GetAllAudiobooksQueryHandler : IRequestHandler<GetAllAudiobooksQuery, IEnumerable<Audiobook>>
{
    private readonly IAudiobookRepository _audiobookRepository;
    public GetAllAudiobooksQueryHandler(IAudiobookRepository audiobookRepository)
    {
        _audiobookRepository = audiobookRepository;
    }

    public async Task<IEnumerable<Audiobook>> Handle(GetAllAudiobooksQuery query, CancellationToken cancellationToken)
    {
        var audiobooks = await _audiobookRepository.GetAllAsync();

        return audiobooks;
    }
}
