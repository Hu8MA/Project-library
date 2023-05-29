using Labrary2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Labrary2023.Data.Repository
{


    public interface Reposotory_author : GenericInterface
    {
       
    }
    public class Implementauthors : Reposotory_author
    {
        public readonly AppDbContext _context;

        public Implementauthors(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                author? b = obj as author ;
                _context.authors.Add(b);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public bool delete<T>(T obj) where T : class
        {
            try
            {
                author? b = obj as author;
                _context.authors.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                author? b = obj as author;
                _context.authors.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            author? b = _context.authors.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T>? list<T>() where T : class
        {
            IEnumerable<author> items = _context.authors.ToList();

            return items as IEnumerable<T>;
        }
    
    
    }
}
