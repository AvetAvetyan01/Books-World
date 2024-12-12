using BooksWorld.Application.Common.Requests.BookBase;
using BooksWorld.Domain.Common.Enums;

namespace BooksWorld.Application.Commands.PaperbookCommands.Create;

public record CreatePaperbookRequest
(
    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher,

    int PagesCount,
    int Quantity,
    int CountOfSales
) : BookBaseRequest(BookId, Language, Year, Price, Publisher);

