using RestWithASP_NET5Udemy.Data.Converter.Implementations;
using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASP_NET5Udemy.Business.Implementation
{
    public class BookBusinessImplementation : IBookBussiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
