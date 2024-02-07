using System.Data;
using Dapper;
using ElmTest.Application.Common.Interfaces;
using ElmTest.Domain.BookAggregate;

namespace ElmTest.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _dbConnection;

        public BookRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string query, int offset, int pageSize)
        {
            var parameters = new
            {
                SearchValue = query,
                Offset = offset,
                PageSize = pageSize
            };

            var books = await _dbConnection.QueryAsync<Book>("p_SearchBooks", parameters, commandType: CommandType.StoredProcedure);
            return books;
        }
        public Task<Book> CreateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            throw new NotImplementedException();
        }



        public Task UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}