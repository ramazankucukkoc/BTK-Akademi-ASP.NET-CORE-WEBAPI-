using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager repositoryManager, ILoggerService loggerService, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public Book CreateOneBook(Book book)
        {
            if (book is null) throw new ArgumentNullException(nameof(book));

            _repositoryManager.Book.CreateOneBook(book);
            _repositoryManager.Save();
            return book;

        }

        public Book DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _repositoryManager.Book.GetOneBookId(id, trackChanges);
            if (entity is null) throw new BookNotFoundException(id);

            _repositoryManager.Book.DeleteOneBook(entity);
            _repositoryManager.Save();
            return entity;

        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {

            var entity= _repositoryManager.Book.GetAll(trackChanges);
            IEnumerable<BookDto> mappedEntity = _mapper.Map<IEnumerable<BookDto>>(entity);
            return mappedEntity;
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            var book = _repositoryManager.Book.GetOneBookId(id, trackChanges);
            if (book is null) throw new BookNotFoundException(id);
            return book;
        }

        public Book UpdateOneBook(int id, BookDtoForUpdate bookDtoForUpdate, bool trackChanges)
        {
            var entity = _repositoryManager.Book.GetOneBookId(id, trackChanges);

            if (entity is null) throw new BookNotFoundException(id);

            entity = _mapper.Map<Book>(bookDtoForUpdate);

            _repositoryManager.Book.Update(entity);
            _repositoryManager.Save();
            return entity;
        }
    }
}
