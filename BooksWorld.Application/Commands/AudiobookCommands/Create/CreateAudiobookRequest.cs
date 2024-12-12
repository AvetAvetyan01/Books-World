using BooksWorld.Application.Common.Requests.BookBase;
using BooksWorld.Domain.Common.Enums;

namespace BooksWorld.Application.Commands.AudiobookCommands.Create;

public sealed record CreateAudiobookRequest
(
    DateTime Duration,
    string Reader,
    string Url,
    string IntroductionUrl,

    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher
) : BookBaseRequest(BookId, Language, Year, Price, Publisher);
