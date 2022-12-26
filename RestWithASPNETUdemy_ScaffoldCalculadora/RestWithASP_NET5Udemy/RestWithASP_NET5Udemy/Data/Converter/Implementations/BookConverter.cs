using RestWithASP_NET5Udemy.Data.Converter.Contract;
using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5Udemy.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origem)
        {
            if (origem == null) return null;

            return new Book
            {
                Id = origem.Id,
                Author = origem.Author,
                Price = origem.Price,
                Title = origem.Title,
                LaunchDate = origem.LaunchDate
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public BookVO Parse(Book origem)
        {
            if (origem == null) return null;

            return new BookVO
            {
                Id = origem.Id,
                Author = origem.Author,
                Price = origem.Price,
                Title = origem.Title,
                LaunchDate = origem.LaunchDate
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin != null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
