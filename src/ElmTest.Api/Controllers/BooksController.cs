using ElmTest.Application.Books.Queries.SearchBooks;
using ElmTest.Contracts.Books;
using ElmTest.Domain.BookAggregate;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElmTest.Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public BooksController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> SearchBooksAsync([FromQuery] string? query = null, [FromQuery] int offset = 0, [FromQuery] int pageSize = 10)
        {
            var books = await _sender.Send(new SearchBooksQuery(query, offset, pageSize));
            var result = _mapper.Map<IEnumerable<Book>, IEnumerable<BookResponse>>(books);
            return Ok(result);
        }

    }
}
