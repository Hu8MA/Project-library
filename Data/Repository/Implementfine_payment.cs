using Labrary2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labrary2023.Data.Repository
{
    public interface Rreposotoryfine_payment :GenericInterface
    {
        public List<SelectListItem> members();

    }
    public class Implementfine_payment : Rreposotoryfine_payment
    {
        public readonly AppDbContext _context;

        public Implementfine_payment(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                fine_payment b = obj as fine_payment;
                _context.fine_Payments.Add(b);
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
                fine_payment b = obj as fine_payment;
                _context.fine_Payments.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                fine_payment b = obj as fine_payment;
                _context.fine_Payments.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            fine_payment b = _context.fine_Payments.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T> list<T>() where T : class
        {
            IEnumerable<fine_payment> items = _context.fine_Payments
                                                                    .Include(a=>a.singelmember)
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


    }
}
