using BooksWorld.Domain.Common.Enums;
using MediatR;

namespace BooksWorld.Application.Commands.EBookCommands.Update;

public record UpdateEBookCommand
(
    int Id,
    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher,

    int PagesCount,
    string Url,
    string IntroductionUrl
) : IRequest;
