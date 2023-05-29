using Labrary2023.Models;

namespace Labrary2023.Data.Repository
{
    public interface Reposotoryreservation_state : GenericInterface
    {

    }
    public class Implementreservation_state : Reposotoryreservation_state
    {
        public readonly AppDbContext _context;

        public Implementreservation_state(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                reservation_state b = obj as reservation_state;
                _context.reservation_States.Add(b);
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
                reservation_state b = obj as reservation_state;
                _context.reservation_States.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                reservation_state b = obj as reservation_state;
                _context.reservation_States.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            reservation_state b = _context.reservation_States.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T> list<T>() where T : class
        {
            IEnumerable<reservation_state> items = _context.reservation_States.ToList();

            return items as IEnumerable<T>;
        }


    }
}
