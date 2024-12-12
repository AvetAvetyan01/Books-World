using MediatR;

namespace BooksWorld.Application.Commands.PaperbookCommands.Update;

public class UpdatePaperbookCommandHandler : IRequestHandler<UpdatePaperbookCommand>
{
    public Task Handle(UpdatePaperbookCommand request, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
