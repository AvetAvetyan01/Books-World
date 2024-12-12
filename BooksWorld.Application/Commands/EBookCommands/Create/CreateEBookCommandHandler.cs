using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.EBookCommands.Create;

public class CreateEBookCommandHandler : IRequestHandler<CreateEBookCommand>
{
    private readonly IMapper _mapper;
    private readonly IEBookRepository _eBookRepository;
    public CreateEBookCommandHandler(IEBookRepository eBookRepository, IMapper mapper)
    {
        _eBookRepository = eBookRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateEBookCommand command, CancellationToken cancellationToken)
    {
        var ebook = _mapper.Map<EBook>(command);

        await _eBookRepository.CreateAsync(ebook);
    }
}
