using BooksWorld.Domain.Interfaces;
using MediatR;

namespace BooksWorld.Application.Commands.AuthorCommands.Delete;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;
    public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(command.Id);
     
        await _authorRepository.DeleteAsync(author);
    }
}
