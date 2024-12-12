using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.BookCommands.Create;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateBookCommand command, CancellationToken token)
    {
        var book = _mapper.Map<Book>(command);

        await _bookRepository.CreateAsync(book);
    }
}
