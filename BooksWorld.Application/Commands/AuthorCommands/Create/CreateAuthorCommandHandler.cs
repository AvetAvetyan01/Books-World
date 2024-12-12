using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.AuthorCommands.Create;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    public CreateAuthorCommandHandler(IAuthorRepository authorRepository,IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }
    
    public async Task Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Author>(command);

        await _authorRepository.CreateAsync(author);
    }
}
