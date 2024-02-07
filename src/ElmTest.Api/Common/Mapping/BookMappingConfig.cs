using ElmTest.Contracts.Books;
using ElmTest.Domain.BookAggregate;
using Mapster;

namespace ElmTest.Domain.Common;

public class BookMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Book, BookResponse>()
            .Map(dest => dest.Id, src => src.BookId)
            .Map(dest => dest.Author, src => src.BookInfo.Author)
            .Map(dest => dest.CoverBase64, src => src.BookInfo.CoverBase64)
            .Map(dest => dest.BookDescription, src => src.BookInfo.BookDescription)
            .Map(dest => dest.BookTitle, src => src.BookInfo.BookTitle)
            .Map(dest => dest.PublishDate, src => src.BookInfo.PublishDate);
    }
}
