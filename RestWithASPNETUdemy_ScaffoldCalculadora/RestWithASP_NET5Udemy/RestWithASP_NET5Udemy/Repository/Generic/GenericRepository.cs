using Microsoft.EntityFrameworkCore;
using RestWithASP_NET5Udemy.Model.Base;
using RestWithASP_NET5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5Udemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(item => item.Id == id);
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public T Update(T item)
        {
            var result = FindById(item.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                return null;
            
        }

        public void Delete(long id)
        {
            var result = FindById(id);
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        
        public bool Exist(long id)
        {
            return dataset.Any(p => p.Id == id);
        }
        
    }
}
