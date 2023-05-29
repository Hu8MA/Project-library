using Labrary2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labrary2023.Data.Repository
{
    public interface Reposotorybook :GenericInterface
    {
        public List<SelectListItem> category();
    }
    public class ImplementBook : Reposotorybook
    {
        public readonly AppDbContext _context;

        public ImplementBook(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                book? b = obj as book;
                _context.books.Add(b);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<SelectListItem> category()
        {

            var result = _context.categories
                         .Select(e => new SelectListItem()
                         {
                             Value = e.idcat.ToString(),
                             Text = e.name
                         }).ToList();

            return result;

        }

        public bool delete<T>(T obj) where T : class
        {
            try
            {
                book? b = obj as book;
                _context.books.Remove(b);
                _context.SaveChanges() ;
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                book? b = obj as book;
                _context.books.Update(b);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            book b = _context.books.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T ;
        }
 
        public IEnumerable<T> list<T>() where T : class
        {
            var items = _context.books.Include(a => a.Category).ToList();

            return items.OfType<T>();
        }
    }
}
