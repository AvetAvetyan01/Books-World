using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Commands.BookCommands.Update;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IBookRepository _bookRepository;
    public UpdateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //_bookRepository.UpdateAsync(new Book(), new Book());

        //return Task.CompletedTask;
    }
}
