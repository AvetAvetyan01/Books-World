using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.AuthorQueries.GetById;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
{
    private readonly IAuthorRepository _authorRepository;
    public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<Author> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(query.Id);

        return author;
    }
}
