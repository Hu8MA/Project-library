using Labrary2023.Models;

namespace Labrary2023.Data.Repository
{
    public interface ReposotoryCategory : GenericInterface
    {

    }
    public class ImplementCategory : ReposotoryCategory
    {
        public readonly AppDbContext _context;

        public ImplementCategory(AppDbContext context)
        {
            _context = context;
        }

        public bool add<T>(T obj) where T : class
        {
            try
            {
                category b = obj as category;
                _context.categories.Add(b);
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
                category b = obj as category;
                _context.categories.Remove(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool edit<T>(T obj) where T : class
        {
            try
            {
                category b = obj as category;
                _context.categories.Update(b);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public T get<T>(int id) where T : class
        {
            category b = _context.categories.Find(id);
            if (b == null)
            {
                return null;
            }
            return b as T;
        }

        public IEnumerable<T> list<T>() where T : class
        {
            IEnumerable<category> items = _context.categories.ToList();

            return items as IEnumerable<T>;
        }

    }
}
