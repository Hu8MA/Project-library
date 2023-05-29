using Labrary2023.Models;

namespace Labrary2023.Data.Repository
{
    public interface Reposotorymember_state : GenericInterface
    {

    }
    public class Implementmember_state : Reposotorymember_state
    {
        public readonly AppDbContext _context;

        public Implementmember_state(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                member_state b = obj as member_state;
                _context.member_States.Add(b);
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
                member_state b = obj as member_state;
                _context.member_States.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                member_state b = obj as member_state;
                _context.member_States.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            member_state b = _context.member_States.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T> list<T>() where T : class
        {
            IEnumerable<member_state> items = _context.member_States.ToList();

            return items as IEnumerable<T>;
        }

    }
}
