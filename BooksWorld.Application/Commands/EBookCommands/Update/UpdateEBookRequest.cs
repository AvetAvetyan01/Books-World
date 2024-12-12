using BooksWorld.Application.Common.Requests.BookBase;
using BooksWorld.Domain.Common.Enums;

namespace BooksWorld.Application.Commands.EBookCommands.Update;

public sealed record UpdateEBookRequest
(
    int Id,
    int PagesCount,
    string Url,
    string IntroductionUrl,

    int BookId, 
    Language Language,
    int Year,
    int Price,
    string Publisher
) : BookBaseRequest(BookId, Language, Year, Price, Publisher);
