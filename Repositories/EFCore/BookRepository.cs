using Entities.Models;
using Microsoft.VisualBasic;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Repositories;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Add(book);
        public void DeleteOneBook(Book book)=>Delete(book);
        public IQueryable<Book> GetAll(bool trackChanges) => FindAll(trackChanges);
        public Book GetOneBookId(int id, bool trackChanges)
     => FindAllCondition(b => b.ID.Equals(id), trackChanges).SingleOrDefault();
        public void UpdateOneBook(Book book) => Update(book);
    }
}
