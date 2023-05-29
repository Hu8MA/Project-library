using Labrary2023.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labrary2023.Data.Repository
{
    public interface Reposotorymember:GenericInterface
    {
        public List<SelectListItem> member_statas();

    }
    public class Implementmember : Reposotorymember
    {
        public readonly AppDbContext _context;

        public Implementmember(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                member? b = obj as member;
                _context.members.Add(b);
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
                member b = obj as member;
                _context.members.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                member b = obj as member;
                _context.members.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            member b = _context.members.Find(id);

            if(b == null)
            {
                return null;
            }
            return b as T;
        }

      
        public IEnumerable<T> list<T>() where T : class
        {
            var items = _context.members.Include(a => a.Member_State).ToList();

            return items.OfType<T>();
        }

        public List<SelectListItem> member_statas()
        {
            var result = _context.member_States
                         .Select(e => new SelectListItem()
                         {
                             Value = e.idmeb_sta.ToString(),
                             Text = e.value_state.ToString()
                         }).ToList();

            return result;

        }

    }
}
