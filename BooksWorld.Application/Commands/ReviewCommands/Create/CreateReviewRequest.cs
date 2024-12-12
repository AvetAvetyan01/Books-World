namespace BooksWorld.Application.Commands.ReviewCommands.Create;

public sealed record CreateReviewRequest
(
    Guid UserId,
    int BookId,
    int Grade,
#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    string? Comment,
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
    DateTime Date
);
