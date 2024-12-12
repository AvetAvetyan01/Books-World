using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.BookCommands.Delete;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBookRepository _bookRepository;
    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(command.Id);

        await _bookRepository.DeleteAsync(book);
    }
}
