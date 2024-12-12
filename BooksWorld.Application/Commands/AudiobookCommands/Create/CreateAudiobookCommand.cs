using BooksWorld.Domain.Common.Enums;
using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Commands.AudiobookCommands.Create;

public sealed record CreateAudiobookCommand
(
    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher,

    DateTime Duration,
    string Reader,
    string Url,
    string IntroductionUrl
) : IRequest<Audiobook>;
