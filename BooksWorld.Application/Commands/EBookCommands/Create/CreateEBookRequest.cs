using BooksWorld.Application.Common.Requests.BookBase;
using BooksWorld.Domain.Common.Enums;

namespace BooksWorld.Application.Commands.EBookCommands.Create;

public record CreateEBookRequest
(
    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher,

    int PagesCount,
    string Url,
    string IntroductionUrl
) : BookBaseRequest(BookId, Language, Year, Price, Publisher);
