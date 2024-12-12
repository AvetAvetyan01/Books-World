using BooksWorld.Domain.Models.User;
using MediatR;

namespace BooksWorld.Application.Queries.UserQueries.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IRequest<User>;
