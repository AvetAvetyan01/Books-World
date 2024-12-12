using BooksWorld.Application.Common.Requests.BookBase;
using BooksWorld.Domain.Common.Enums;

namespace BooksWorld.Application.Commands.PaperbookCommands.Update;

public sealed record UpdatePaperbookRequest
(
    int Id,
    int PagesCount,
    int Quantity,
    int CountOfSales,

    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher
) : BookBaseRequest(BookId, Language, Year, Price, Publisher);

