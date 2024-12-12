using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.AudiobookQueries.GetById;

public class GetAudiobookByIdQueryHandler : IRequestHandler<GetAudiobookByIdQuery,Audiobook>
{
    private readonly IAudiobookRepository _audiobookRepository;
    public GetAudiobookByIdQueryHandler(IAudiobookRepository audiobookRepository)
    {
        _audiobookRepository = audiobookRepository;
    }

    public async Task<Audiobook> Handle(GetAudiobookByIdQuery query, CancellationToken cancellationToken)
    {
        var audiobook = await _audiobookRepository.GetByIdAsync(query.Id);

        return audiobook;
    }
}
