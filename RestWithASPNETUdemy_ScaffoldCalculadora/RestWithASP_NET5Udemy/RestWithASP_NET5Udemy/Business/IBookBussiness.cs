using RestWithASP_NET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Business
{
    public interface IBookBussiness
    {
        Book FindById(int id);
        List<Book> FindAll();
        Book Create(Book book);
        Book Update(Book book);
        void Delete(int id);
    }
}
