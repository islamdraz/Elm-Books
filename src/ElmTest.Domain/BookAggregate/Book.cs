using ElmTest.Domain.Common;

namespace ElmTest.Domain.BookAggregate;

public class Book  //: AggregateRoot
{
    public Int64 BookId { get; set; }
    public DateTime LastModified { get; set; }
    public BookInfo BookInfo { get; set; }
}