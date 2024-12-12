using BooksWorld.Domain.Common.Collections;
using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.AuthorQueries.GetByPage;

public class GetAuthorByPageQueryHandler : IRequestHandler<GetAuthorByPageQuery, PagedCollection<Author>>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorByPageQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<PagedCollection<Author>> Handle(GetAuthorByPageQuery request, CancellationToken cancellationToken)
    {
        var authors = await _authorRepository.GetAllAsync();
        var pagedAuthors = PagedCollection<Author>.ToPagedCollection(authors,1,30);
        
        return pagedAuthors;
    }
}
