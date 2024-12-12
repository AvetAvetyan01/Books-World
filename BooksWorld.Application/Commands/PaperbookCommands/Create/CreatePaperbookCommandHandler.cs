using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.Book;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.PaperbookCommands.Create;

public class CreatePaperbookCommandHandler : IRequestHandler<CreatePaperbookCommand>
{
#pragma warning disable CS0649 // Полю "CreatePaperbookCommandHandler._mapper" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
    private readonly IMapper _mapper;
#pragma warning restore CS0649 // Полю "CreatePaperbookCommandHandler._mapper" нигде не присваивается значение, поэтому оно всегда будет иметь значение по умолчанию null.
    private readonly IPaperbookRepository _paperbookRepository;
    public CreatePaperbookCommandHandler(IPaperbookRepository paperbookRepository)
    {
        _paperbookRepository = paperbookRepository;
    }

    public async Task Handle(CreatePaperbookCommand command, CancellationToken cancellationToken)
    {
        var paperbook = _mapper.Map<Paperbook>(command);

        await _paperbookRepository.CreateAsync(paperbook);
    }
}
