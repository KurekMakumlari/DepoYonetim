using System;
using System.Data.Entity;
using System.Linq;
using DepoYonetim.Core.Enums;

namespace DepoYonetim.DataAccess.Repostories
{
    public class Repository : IDisposable
    {
        private readonly DepoYonetimDbContext _context;

        public Repository(string conString)
        {
            _context = new DepoYonetimDbContext(conString);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>();
        }

        public T GetById<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public (bool success, State state, string message) Add<T>(T entity) where T : class
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return (true, State.Success, "Success");
            }
            catch (Exception ex)
            {
                return (false, State.Fail, ex.Message);
            }
        }

        public (bool success, State state, string message) Update<T>(T entity) where T : class
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return (true, State.Success, "Success");
            }
            catch (Exception ex)
            {
                return (false, State.Fail, ex.Message);
            }
        }

        public (bool success, State state, string message) Delete<T>(T entity) where T : class
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return (true, State.Success, "Success");
            }
            catch (Exception ex)
            {
                return (false, State.Fail, ex.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
