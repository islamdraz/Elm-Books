namespace ElmTest.Application.Books.Queries.SearchBooks;

using System.Collections.Generic;
using ElmTest.Domain.BookAggregate;
using MediatR;
public record SearchBooksQuery(string? Query, int Offset, int PageSize) : IRequest<IEnumerable<Book>>;

