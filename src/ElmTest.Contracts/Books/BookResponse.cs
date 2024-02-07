namespace ElmTest.Contracts.Books
{
    public record BookResponse(Int64 Id, string Author, string BookTitle, string BookDescription, DateTime PublishDate, string CoverBase64);
}