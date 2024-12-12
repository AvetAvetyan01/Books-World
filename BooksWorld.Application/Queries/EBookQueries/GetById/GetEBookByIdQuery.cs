using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.EBookQueries.GetById;

public sealed record GetEBookByIdQuery(int Id) : IRequest<EBook>;
