using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.EBookCommands.Delete;

public class DeleteEBookCommandHandler : IRequestHandler<DeleteEBookCommand>
{
    private readonly IEBookRepository _eBookRepository;
    public DeleteEBookCommandHandler(IEBookRepository eBookRepository)
    {
        _eBookRepository = eBookRepository;
    }

    public async Task Handle(DeleteEBookCommand command, CancellationToken cancellationToken)
    {
        var ebook = await _eBookRepository.GetByIdAsync(command.Id);

        await _eBookRepository.DeleteAsync(ebook);
    }
}
