using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.ReviewCommands.Delete;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IReviewRepository _reviewRepository;
    public DeleteReviewCommandHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetByIdAsync(request.Id);

        await _reviewRepository.DeleteAsync(review);
    }
}
