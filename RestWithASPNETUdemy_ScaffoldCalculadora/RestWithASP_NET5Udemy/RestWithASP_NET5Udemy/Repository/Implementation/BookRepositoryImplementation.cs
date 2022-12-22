using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Repository.Implementation
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(int id)
        {
            return _context.Books.SingleOrDefault(b => b.Id == id);
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }

            return book;
        }

        public Book Update(Book book)
        {
            if (!Exist(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(b => b.Id == book.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return book;
        }

        public void Delete(int id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id == id);
            _context.Books.Remove(result);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Books.Any(p => p.Id == id);
        }
    }
}
