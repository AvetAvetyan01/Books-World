using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Commands.AuthorCommands.Update;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;

    public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public Task Handle(UpdateAuthorCommand request, CancellationToken token)
    {
        throw new NotImplementedException();

        //_authorRepository.UpdateAsync(new Author(),new Author());

        //return Task.CompletedTask;
    }
}
