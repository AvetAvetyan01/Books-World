using FluentValidation;

namespace BooksWorld.Application.Queries.BookQueries.GetCollection;

public class GetBooksCollectionRequestValidator : AbstractValidator<GetBooksCollectionRequest>
{
    public GetBooksCollectionRequestValidator()
    {
        RuleFor(b => b.Size)
            .NotNull()
            .NotEmpty();

        RuleFor(b => b.AuthorId)
            .GreaterThan(0);

        RuleFor(b => b.GenreId)
            .NotEqual(0);

        RuleFor(b => b.MinYear)
            .GreaterThan(0);

        RuleFor(b => b.MaxYear)
            .GreaterThan(0)
            .GreaterThan(b => b.MinYear);

        RuleFor(b => b.MinPagesCount)
            .GreaterThan(0);

        RuleFor(b => b.MaxPagesCount)
            .GreaterThan(0)
            .GreaterThan(b => b.MinPagesCount);

        RuleFor(b => b.MinPrice)
            .GreaterThan(0);

        RuleFor(b => b.MaxPrice)
            .GreaterThan(0)
            .GreaterThan(b => b.MinPrice);

        RuleFor(b => b.HighRating)
            .NotNull()
            .NotEmpty();

        RuleFor(b => b.Discount)
            .NotNull()
            .NotEmpty();

        RuleFor(b => b.Languages)
            .IsInEnum();

        RuleFor(b => b.Formats)
            .IsInEnum();
    }
}
