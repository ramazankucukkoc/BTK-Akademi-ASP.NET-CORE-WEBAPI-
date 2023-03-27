using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks(bool trackChanges);
        Book GetOneBookById(int id, bool trackChanges);
        Book CreateOneBook(Book book);
        Book UpdateOneBook(int id, BookDtoForUpdate bookDtoForUpdate, bool trackChanges);
        Book DeleteOneBook(int id,bool trackChanges);

    }
}
