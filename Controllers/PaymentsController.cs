using Labrary2023.Data.Repository;
using Labrary2023.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labrary2023.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        public readonly Reposotoryloan _reloan;
        public readonly Reposotoryreservation _reRes;
        public readonly Reposotoryreservation_state _reResSta;
        public readonly Reposotoryfine _refine;

        public PaymentsController(Reposotoryloan reloan , Reposotoryreservation reRes , Reposotoryreservation_state reResSta , Reposotoryfine refine)
        {
            _refine = refine;
            _reloan = reloan;
            _reRes = reRes;
            _reResSta = reResSta;
        }
        public ActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public ActionResult listreservationstate()
        {
            IEnumerable<reservation_state> items = _reResSta.list<reservation_state>();

            return View(items);
        }

        [HttpGet]
        public ActionResult addreservationstate()
        {
        
            return View();
        }

        [HttpPost]
        public ActionResult addreservationstate(reservation_state obj)
        {
            if (ModelState.IsValid)
            {
                _reResSta.add(obj);
                return RedirectToAction("listreservationstate");
            }
           
            return View(obj);
        }

        [HttpGet]
        public ActionResult editreservationstate(int id)
        {
            var item = _reResSta.get<reservation_state>(id);

            if (item != null)
            {
               
                return View(item);

            }
            return RedirectToAction("Error");

        }

        [HttpPost]
        public ActionResult editreservationstate(reservation_state obj)
        {
            if (ModelState.IsValid)
            {
                _reResSta.edit(obj);
                return RedirectToAction("listreservationstate");
            }
           
            return View(obj);
        }


        [HttpGet, HttpPost]
        public ActionResult deletereservationstate(int id)
        {
            _reResSta.delete(_reResSta.get<reservation_state>(id));

            return RedirectToAction("listreservationstate");

        }

         

        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
      
        
        [HttpGet]
        public ActionResult listreservation()
        {
            IEnumerable<reservation> items = _reRes.list<reservation>();
            return View(items);
        }

        [HttpGet]
        public ActionResult addreservation()
        {
            ViewBag.idmeb = _reRes.members();
            ViewBag.idbook = _reRes.books();
            ViewBag.reservation_states_id = _reRes.reservation_status();
            return View();
        }

        [HttpPost]
        public ActionResult addreservation(reservation obj )
        {
            if(ModelState.IsValid)
            {
                _reRes.add(obj);
                return RedirectToAction("listreservation");
            }
            ViewBag.idmeb = _reRes.members();
            ViewBag.idbook = _reRes.books();
            ViewBag.reservation_states_id = _reRes.reservation_status();
            return View(obj);
        }

        [HttpGet]
        public ActionResult editreservation(int id)
        {
            var item = _reRes.get<reservation>(id);

            if(item != null)
            {
                ViewBag.idmeb = _reRes.members();
                ViewBag.idbook = _reRes.books();
                ViewBag.reservation_states_id = _reRes.reservation_status();
                return View(item);

            }
            return RedirectToAction("Error");

        }

        [HttpPost]
        public ActionResult editreservation(reservation obj)
        {
            if (ModelState.IsValid)
            {
                _reRes.edit(obj);
                return RedirectToAction("listreservation");
            }
            ViewBag.idmeb = _reRes.members();
            ViewBag.idbook = _reRes.books();
            ViewBag.reservation_states_id = _reRes.reservation_status();
            return View(obj);
        }


        [HttpGet,HttpPost]
        public ActionResult deletereservation(int id)
        {
             _reRes.delete(_reRes.get<reservation>(id));

            return RedirectToAction("listreservation");

        }



        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
        /// 


        [HttpGet]
        public ActionResult listloan()
        {
            IEnumerable<loan> items = _reloan.list<loan>();

            return View(items);
        }

        [HttpGet]
        public ActionResult addloan()
        {
            ViewBag.idmeb = _reloan.members();
            ViewBag.idbook = _reloan.books();
            return View();
        }

        [HttpPost]
        public ActionResult addloan(loan obj)
        {
            if (ModelState.IsValid)
            {
                _reloan.add(obj);
                return RedirectToAction("listloan");
            }
            ViewBag.idmeb = _reloan.members();
            ViewBag.idbook = _reloan.books();
            return View(obj);
        }

        [HttpGet]
        public ActionResult editloan(int id)
        {
            var item = _reloan.get<loan>(id);

            if (item != null)
            {
                ViewBag.idmeb = _reloan.members();
                ViewBag.idbook = _reloan.books();
                return View(item);

            }
            return RedirectToAction("Error");

        }

        [HttpPost]
        public ActionResult editloan(loan obj)
        {
            if (ModelState.IsValid)
            {
                _reloan.edit(obj);
                return RedirectToAction("listloan");
            }
            ViewBag.idmeb = _reloan.members();
            ViewBag.idbook = _reloan.books();
            return View(obj);
        }


        [HttpGet, HttpPost]
        public ActionResult deleteloan(int id)
        {
            _reloan.delete(_reloan.get<loan>(id));

            return RedirectToAction("listloan");

        }



        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult listfine()
        {
            IEnumerable<fine> items = _refine.list<fine>();

            return View(items);
        }

        [HttpGet]
        public ActionResult addfine()
        {
            ViewBag.idlon = _refine.Loans();
            return View();
        }

        [HttpPost]
        public ActionResult addfine(fine obj)
        {
            if (ModelState.IsValid)
            {
                _refine.add(obj);
                return RedirectToAction("listfine");
            }
            ViewBag.idlon = _refine.Loans();
            return View(obj);
        }

        [HttpGet]
        public ActionResult editfine(int id)
        {
            var item = _refine.get<fine>(id);

            if (item != null)
            {
                ViewBag.idlon = _refine.Loans();

                return View(item);

            }
            return RedirectToAction("Error");

        }

        [HttpPost]
       
        public ActionResult editfine(fine obj)
        {
            if (ModelState.IsValid)
            {
                _refine.edit(obj);
                return RedirectToAction("listfine");
            }
            ViewBag.idlon = _refine.Loans();

            return View(obj);
        }


        [HttpGet, HttpPost]
        public ActionResult deletefine(int id)
        {
            _refine.delete(_refine.get<fine>(id));

            return RedirectToAction("listfine");

        }








    }
}
