using System.Buffers.Text;
using ElmTest.Domain.Common;

namespace ElmTest.Domain.BookAggregate;

public class BookInfo : ValueObject
{
    public string Author { get; }
    public string BookTitle { get; }
    public string BookDescription { get; }
    public DateTime PublishDate { get; }
    public string CoverBase64 { get; }


    public BookInfo(string author, string bookTitle, string bookDescription, DateTime publishDate, string coverBase64)
    {
        Author = author;
        BookTitle = bookTitle;
        BookDescription = bookDescription;
        PublishDate = publishDate;
        CoverBase64 = coverBase64;
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Author;
        yield return BookTitle;
        yield return BookDescription;
        yield return PublishDate;
        yield return CoverBase64;
    }
}