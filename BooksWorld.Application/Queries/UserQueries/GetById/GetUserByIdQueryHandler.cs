using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models.User;
using MediatR;

namespace BooksWorld.Application.Queries.UserQueries.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;
    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
