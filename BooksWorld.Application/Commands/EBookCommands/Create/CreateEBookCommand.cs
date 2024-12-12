using BooksWorld.Domain.Common.Enums;
using MediatR;

namespace BooksWorld.Application.Commands.EBookCommands.Create;

public sealed record CreateEBookCommand(
    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher,
    int PagesCount,
    string Url,
    string IntroductionUrl
) : IRequest;
