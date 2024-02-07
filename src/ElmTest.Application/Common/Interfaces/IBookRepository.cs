namespace ElmTest.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElmTest.Domain.BookAggregate;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<IEnumerable<Book>> SearchBooksAsync(string? query, int offset, int pageSize);

    Task<Book> GetBookByIdAsync(Int64 id);

    Task<Book> CreateBookAsync(Book book);

    Task UpdateBookAsync(Book book);

    Task DeleteBookAsync(Int64 id);
}

