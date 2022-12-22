using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Repository;
using RestWithASP_NET5Udemy.Repository.Generic;
using RestWithASP_NET5Udemy.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Business.Implementation
{
    public class BookBusinessImplementation : IBookBussiness
    {
        private readonly IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
