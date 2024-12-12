using BooksWorld.Domain.Models.Book;
using MediatR;

namespace BooksWorld.Application.Queries.AudiobookQueries.GetAll;

public sealed record GetAllAudiobooksQuery : IRequest<IEnumerable<Audiobook>>;
