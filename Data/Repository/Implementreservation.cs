using Labrary2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labrary2023.Data.Repository
{

    public interface Reposotoryreservation :GenericInterface
    {
        public List<SelectListItem> books();
        public List<SelectListItem> members();
        public List<SelectListItem> reservation_status();
    }
    public class Implementreservation : Reposotoryreservation
    {
        public readonly AppDbContext _context;

        public Implementreservation(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                reservation b = obj as reservation;
                _context.reservations.Add(b);
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
                reservation b = obj as reservation;
                _context.reservations.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                reservation b = obj as reservation;
                _context.reservations.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            reservation b = _context.reservations.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T> list<T>() where T : class
        {
            IEnumerable<reservation> items = _context.reservations
                                                                .Include(a => a.reservation_states)
                                                                .Include(a => a.Book)
                                                                .Include(a =>a.Member).ToList();

            return items as IEnumerable<T>;
        }

       
        
        
        public List<SelectListItem> members()
        {
            var result = _context.members
                         .Select(e => new SelectListItem()
                         {
                             Value = e.idmeb.ToString(),
                             Text = e.Fname +" "+e.Lname
                         }).ToList();

            return result;
            
        }

        public List<SelectListItem> reservation_status()
        {
            var result = _context.reservation_States
                         .Select(e => new SelectListItem()
                         {
                             Value = e.idres_sta.ToString(),
                             Text = e.value_state.ToString()
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
