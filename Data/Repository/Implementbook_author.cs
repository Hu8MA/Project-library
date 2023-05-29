using Labrary2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labrary2023.Data.Repository
{
    public interface Reposotorybook_author:GenericInterface
    {
        public List<SelectListItem> authoers();
        public List<SelectListItem> books();
    }

    public class Implementbook_author  : Reposotorybook_author
    {
  
        public readonly AppDbContext _context;

        public Implementbook_author (AppDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> authoers()
        {

            var result = _context.authors
                         .Select(e => new SelectListItem()
                         {
                             Value = e.idAuthor.ToString(),
                             Text = e.Fname + " " + e.Lname.ToString()
                         }).ToList();

            return result;

        }    
        public List<SelectListItem> books()
        {

            var result = _context.books
                         .Select(e => new SelectListItem()
                         {
                             Value = e.idbook.ToString(),
                             Text = e.title.ToString()
                         }).ToList();

            return result;

        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                book_author? b = obj as book_author;
                _context.book_Authors.Add(b);
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
                book_author? b = obj as book_author;
                _context.book_Authors.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                book_author? b = obj as book_author;
                _context.book_Authors.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            book_author? b = _context.book_Authors.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T> list<T>() where T : class
        {
            var items = _context.book_Authors.Include(a => a.Author).Include(a => a.Book).ToList(); 
            return items.OfType<T>();
        }

    }
}
