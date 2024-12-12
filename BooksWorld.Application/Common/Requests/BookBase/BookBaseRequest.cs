using BooksWorld.Domain.Common.Enums;

namespace BooksWorld.Application.Common.Requests.BookBase;

public record BookBaseRequest
(
    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher
);
