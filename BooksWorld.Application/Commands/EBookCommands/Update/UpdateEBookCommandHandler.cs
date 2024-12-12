using BooksWorld.Domain.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;

namespace BooksWorld.Application.Commands.EBookCommands.Update;

public class UpdateEBookCommandHandler : IRequestHandler<UpdateEBookCommand>
{
    private readonly IMapper _mapper; 
    private readonly IEBookRepository _eBookRepository;
    public UpdateEBookCommandHandler(IEBookRepository eBookRepository, IMapper mapper)
    {
        _eBookRepository = eBookRepository;    
        _mapper = mapper;
    }

    public async Task Handle(UpdateEBookCommand command, CancellationToken cancellationToken)
    {
        var ebook = await _eBookRepository.GetByIdAsync(command.Id);

        var updatedEbook = _mapper.Map(command,ebook);

        await _eBookRepository.UpdateAsync(updatedEbook);
    }
}
