namespace ElmTest.Application.Books.Queries.SearchBooks;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElmTest.Application.Common.Interfaces;
using ElmTest.Domain.BookAggregate;
using MediatR;

public class SearchBooksQueryHandler : IRequestHandler<SearchBooksQuery, IEnumerable<Book>>
{
    private readonly IBookRepository _bookRepository;

    public SearchBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> Handle(SearchBooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.SearchBooksAsync(request.Query, request.Offset, request.PageSize);
    }
}
