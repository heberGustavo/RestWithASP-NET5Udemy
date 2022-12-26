using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Business
{
    public interface IBookBussiness
    {
        BookVO FindById(int id);
        List<BookVO> FindAll();
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(int id);
    }
}
