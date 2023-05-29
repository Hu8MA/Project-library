using Labrary2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labrary2023.Data.Repository
{
    public interface Reposotoryloan: GenericInterface
    {
        public List<SelectListItem> members();
        public List<SelectListItem> books();


    }
    public class Implementloan : Reposotoryloan
    {
        public readonly AppDbContext _context;

        public Implementloan(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                loan b = obj as loan;
                _context.loans.Add(b);
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
                loan b = obj as loan;
                _context.loans.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                loan b = obj as loan;
                _context.loans.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            loan b = _context.loans.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T> list<T>() where T : class
        {
            IEnumerable<loan> items = _context.loans
                                                    .Include(a => a.Book)
                                                    .Include(b => b.Member)
                                                    .ToList();
            return items as IEnumerable<T>;
        }


        public List<SelectListItem> members()
        {
            var result = _context.members
                         .Select(e => new SelectListItem()
                         {
                             Value = e.idmeb.ToString(),
                             Text = e.Fname + " " + e.Lname
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

    }
}
