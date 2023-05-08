using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(Context context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public void Delete(T t)
        {
            _dbSet.Remove(t);
            _context.SaveChanges();

        }

        public T GetByID(int id)
        {
           return _dbSet.Find(id);
        }

        public List<T> GetList()
        {
             return _dbSet.ToList();    
        }

        public void Insert(T t)
        {
            _dbSet.Add(t);  
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _dbSet.Update(t);
            _context.SaveChanges(); 
        }
    }
}
