using BooksWorld.Domain.Interfaces;
using BooksWorld.Domain.Models;
using MediatR;

namespace BooksWorld.Application.Queries.AuthorQueries.GetAll
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery query, CancellationToken cancellationToken)
        {
            var authors = _authorRepository.GetAllAsync();

            return authors;
        }
    }
}
