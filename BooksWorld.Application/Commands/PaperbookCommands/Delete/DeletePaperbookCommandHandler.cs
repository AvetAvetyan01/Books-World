using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.PaperbookCommands.Delete;

public class DeletePaperbookCommandHandler : IRequestHandler<DeletePaperbookCommand>
{
    private readonly IPaperbookRepository _paperbookRepository;
    public DeletePaperbookCommandHandler(IPaperbookRepository paperbookRepository)
    {
        _paperbookRepository = paperbookRepository; 
    }

    public async Task Handle(DeletePaperbookCommand command, CancellationToken cancellationToken)
    {
        var paperbook = await _paperbookRepository.GetByIdAsync(command.Id);
        
        await _paperbookRepository.DeleteAsync(paperbook);
    }
}
