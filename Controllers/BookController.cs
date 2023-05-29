using Labrary2023.Data.Repository;
using Labrary2023.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labrary2023.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        public readonly Reposotorybook _reBook;
        public readonly Reposotorybook_author _reBookAuthor;
        public readonly ReposotoryCategory _reCategory;
        public readonly Reposotory_author _reAuthoer;

        public BookController(Reposotorybook   reBook , ReposotoryCategory  reCategory , Reposotorybook_author reBookAuthor , Reposotory_author  reAuthoer)
        {
            _reAuthoer = reAuthoer;
            _reBook = reBook;
            _reBookAuthor = reBookAuthor;
            _reCategory=reCategory;
        }

        public IActionResult index()
        {
           
            return View();
        }



        [HttpGet]
        public ActionResult listbook()
        {
            IEnumerable<book> item = _reBook.list<book>()  ;
            return View(item);
        }  
        

        [HttpGet,HttpPost]
        public ActionResult DeleteBook(int id)
        {  
            _reBook.delete(_reBook.get<book>(id));
            return RedirectToAction("listbook");
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            ViewBag.idcat = _reBook.category();
            return View();
        } 
        
        [HttpPost]
        public ActionResult AddBook(book obj)
        {
            if(ModelState.IsValid)
            {
                _reBook.add(obj);
                return RedirectToAction("listbook");
            }
            else
            {  
                foreach (var error in ModelState )
                    {
                        ModelState.AddModelError("", error+"");
                    }
                ViewBag.idcat = _reBook.category();
                return View(obj);

            }
          
        }


        [HttpGet]
        public ActionResult editbook(int id)
        {
            var item = _reBook.get<book>(id);
            ViewBag.idcat = _reBook.category();
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Error");
            
        }

        [HttpPost]
        public ActionResult editbook(book obj)
        {
            if (ModelState.IsValid)
            {
                _reBook.edit(obj);
                return RedirectToAction("listbook");
            }

            ViewBag.idcat = _reBook.category();

            return View(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public ActionResult listCategory()
        {
            IEnumerable<category> item = _reCategory.list<category>()  ;
            return View(item);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(category obj)
        {
            if (ModelState.IsValid)
            {
                _reCategory.add(obj);
                return RedirectToAction("listCategory");
            }

          
            return View(obj);
        }



        [HttpGet, HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            _reCategory.delete(_reCategory.get<category>(id));
            return RedirectToAction("listCategory");
        }

         
        [HttpGet]
        public ActionResult editCategory(int id)
        {
            var item = _reCategory.get<category>(id);
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Error");
           
        }

        [HttpPost]
        public ActionResult editCategory(category obj)
        {
            if (ModelState.IsValid)
            {
                _reCategory.edit(obj);
                return RedirectToAction("listCategory");
            }


            return View(obj);
        }

      
        /// <summary>
        /// //////
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult listBookAuthor()
        {
            IEnumerable<book_author> item = _reBookAuthor.list<book_author>();
            return View(item);
        }

        [HttpGet]
        public ActionResult AddBookAuthor()
        {
            ViewBag.idbook =   _reBookAuthor.books();
            ViewBag.idAuthor = _reBookAuthor.authoers();
            return View();
        }

        [HttpPost]
        public ActionResult AddBookAuthor(book_author obj)
        {
            if (ModelState.IsValid)
            {
                _reBookAuthor.add (obj);
                return RedirectToAction("listBookAuthor");
            }

            ViewBag.idbook = _reBookAuthor.books();
            ViewBag.idAuthor = _reBookAuthor.authoers();
            return View(obj);
        }



        [HttpGet, HttpPost]
        public ActionResult DeleteBookAuthor(int id)
        {
            _reBookAuthor.delete(_reBookAuthor.get<book_author>(id));
            return RedirectToAction("listBookAuthor");
        }


        [HttpGet]
        public ActionResult editBookAuthor(int id)
        {
            var item = _reBookAuthor.get<book_author>(id);
            ViewBag.idbook = _reBookAuthor.books();
            ViewBag.idAuthor = _reBookAuthor.authoers();

            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Error");
            
        }

        [HttpPost]
        public ActionResult editBookAuthor(book_author obj)
        {
            if (ModelState.IsValid)
            {
                _reBookAuthor.edit(obj);
                return RedirectToAction("listBookAuthor");
            }
            ViewBag.idbook = _reBookAuthor.books();
            ViewBag.idAuthor = _reBookAuthor.authoers();
            return View(obj);
        }



        /// <summary>
        /// //////
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public ActionResult listAuthor()
        {
            IEnumerable<author> item = _reAuthoer.list<author>();
            return View(item);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(author obj)
        {
            if (ModelState.IsValid)
            {
                _reAuthoer.add<author>(obj);
                return RedirectToAction("listAuthor");
            }

 
            return View(obj);
        }



        [HttpGet,HttpPost]
        public ActionResult DeleteAuthor(int id)
        {
            _reAuthoer.delete(_reAuthoer.get<author>(id));
            return RedirectToAction("listAuthor");
        }


        [HttpGet]
        public ActionResult editAuthor(int id)
        {
            var item = _reAuthoer.get<author>(id);
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Error");
        
        }

        [HttpPost]
        public ActionResult editAuthor(author obj)
        {
            if (ModelState.IsValid)
            {
                _reAuthoer.edit(obj);
                return RedirectToAction("listAuthor");
            }
   
            return View(obj);
        }



    }
}
