using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.ReviewCommands.Create;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;
    public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = _mapper.Map<Review>(command);

        await _reviewRepository.CreateAsync(review);
    }
}
