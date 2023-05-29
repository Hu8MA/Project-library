using Labrary2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.WebSockets;

namespace Labrary2023.Data.Repository
{
    public interface Reposotoryfine:GenericInterface
    {
         public  List<SelectListItem>  Loans();
    }
    public class Implementfine : Reposotoryfine
    {
        public readonly AppDbContext _context;

        public Implementfine(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                fine b = obj as fine;
                _context.fines.Add(b);
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
                fine b = obj as fine;
                _context.fines.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                fine b = obj as fine;
                _context.fines.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            fine? b = _context.fines.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T> list<T>() where T : class
        {
            IEnumerable<fine> items = _context.fines
                                                    .Include(a => a.Loan).Include(a=>a.Loan.Member)
                                                    .ToList();


            return items as IEnumerable<T>;
        }

    

        public List<SelectListItem> Loans()
        {
            IEnumerable<loan> items = _context.loans
                                                 .Include(a => a.Book)
                                                 .Include(b => b.Member)
                                                 .ToList();
 
          
            var x = items.Select(e => new SelectListItem
            {
                Value=e.idlo.ToString(),
                Text =e.Member.Fname.ToString(),
            }).ToList();

            
            return x;
        }
 
      


    }
}