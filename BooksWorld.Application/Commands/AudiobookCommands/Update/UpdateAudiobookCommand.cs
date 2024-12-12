using BooksWorld.Domain.Common.Enums;
using MediatR;

namespace BooksWorld.Application.Commands.AudiobookCommands.Update;

public record UpdateAudiobookCommand 
(
    int Id,
    DateTime Duration,
    string Reader,
    string Url,
    string IntroductionUrl,

    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher
) : IRequest;
