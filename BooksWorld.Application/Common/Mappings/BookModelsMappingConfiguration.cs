using BooksWorld.Application.Queries.BookQueries.GetCollection;
using BooksWorld.Application.Queries.BookQueries.GetPaged;
using Mapster;

namespace BooksWorld.Application.Mappings;

public class BookModelsMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetPagedBooksRequest, GetPagedBooksQuery>()
            .Map(dst => dst.Filter, src => src);

        config.NewConfig<GetBooksCollectionRequest, GetBooksCollectionQuery>()
            .Map(dst => dst.Filter, src => src);
    }
}
