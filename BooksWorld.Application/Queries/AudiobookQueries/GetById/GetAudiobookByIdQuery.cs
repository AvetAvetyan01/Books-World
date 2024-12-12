using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.AudiobookQueries.GetById;

public sealed record GetAudiobookByIdQuery(int Id) : IRequest<Audiobook>;
