using BooksWorld.Domain.Common.Enums;
using MediatR;

namespace BooksWorld.Application.Commands.PaperbookCommands.Update;

public record UpdatePaperbookCommand 
(
    int BookId,
    Language Language,
    int Year,
    int Price,
    string Publisher,

    int PagesCount,
    int Quantity,
    int CountOfSales
) : IRequest;
