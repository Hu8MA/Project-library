using Labrary2023.Data.Repository;
using Labrary2023.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labrary2023.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly Reposotorymember _rememper;
        private readonly Reposotorymember_state _rememperstate;
        private readonly Rreposotoryfine_payment _refinepay;
  
        public MemberController(Reposotorymember rememper , Reposotorymember_state rememperstate , Rreposotoryfine_payment refinepay)
        {
            _refinepay = refinepay;
            _rememper = rememper;
            _rememperstate = rememperstate;
        }

        public ActionResult Index()
        {
            return View();
        }
 
        /// <summary>
        /// //////////
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult listmember()
        {
            IEnumerable<member>items = _rememper.list<member>();
            return View(items);
        }

        [HttpGet]
        public ActionResult Addmember() 
        {
            ViewBag.idmeb_sta = _rememper.member_statas();
            return View();
        }
       
        [HttpPost]
        public ActionResult Addmember(member obj)
        {
            if(ModelState.IsValid)
            {
                _rememper.add<member>(obj);
                return RedirectToAction("listmember");
            }
            ViewBag.idmeb_sta = _rememper.member_statas();

            return View(obj);
        }

 
        [HttpGet]
        public ActionResult editmember(int id)
        {
            var item = _rememper.get<member>(id);
            ViewBag.idmeb_sta = _rememper.member_statas();
            
            if(item != null)
            {
                return View(item);
            }
            return RedirectToAction("Error");
          
        }
        
        [HttpPost]
        public ActionResult editmember(member obj)
        {


            if(ModelState.IsValid)
            {
                _rememper.edit<member>(obj);
                return RedirectToAction("listmember");
            }
            ViewBag.idmeb_sta = _rememper.member_statas();
            return View(obj) ;
        }
         
        [HttpGet,HttpPost]
        public ActionResult Deletemember(int id)
        {
            _rememper.delete(_rememper.get<member>(id));
            return RedirectToAction("listmember");
        }

        /////////////////
        /////////////////
        /////////////////
     


        [HttpGet]
        public ActionResult listmemberstate()
        {
            IEnumerable<member_state> items =_rememperstate.list<member_state>();
            return View(items);
        }

        [HttpGet]
        public ActionResult addmemberstate()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult addmemberstate(member_state obj)
        {
            if(ModelState.IsValid)
            {
                _rememperstate.add(obj);
                return RedirectToAction("listmemberstate");
            }
            return View(obj);
        }
 
        [HttpGet]
        public ActionResult editmemberstate(int id)
        {
            var item = _rememperstate.get<member_state>(id);
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Error");
           
        }
        [HttpPost]
        public ActionResult editmemberstate(member obj)
        {
            if (ModelState.IsValid)
            {
                _rememperstate.edit(obj);
                return RedirectToAction("listmemberstate");
            }
            return View(obj);
            
        }

        [HttpGet, HttpPost]
        public ActionResult Deletememberstate(int id)
        {
            _rememperstate.delete<member_state>(_rememperstate.get<member_state>(id));
            return View();
        }

        /////////////////
        /////////////////
        /////////////////

        [HttpGet]
        public ActionResult listfine_payment()
        {
            IEnumerable<fine_payment> items = _refinepay.list<fine_payment>();
            return View(items);
        }

        [HttpGet]
        public ActionResult addfine_payment()
        {
            ViewBag.idmeb = _refinepay.members();
            return View();
        }

        [HttpPost]
        public ActionResult addfine_payment(fine_payment obj)
        {
            if (ModelState.IsValid)
            {
                _refinepay.add(obj);
                return RedirectToAction("listfine_payment");
            }
            ViewBag.idmeb = _refinepay.members();

            return View(obj);
        }

        [HttpGet]
        public ActionResult editfine_payment(int id)
        {
            var item = _refinepay.get<fine_payment>(id);
            ViewBag.idmeb = _refinepay.members();

            if (item != null)
            {
                return View(item);
            }

            return RedirectToAction("Error");

        }
     
        [HttpPost]
        public ActionResult editfine_payment(fine_payment obj)
        {
            if (ModelState.IsValid)
            {
                _refinepay.edit(obj);
                return RedirectToAction("listfine_payment");
            }
            ViewBag.idmeb = _refinepay.members();

            return View(obj);

        }

        [HttpGet, HttpPost]
        public ActionResult Deletefine_payment(int id)
        {
            _refinepay.delete<fine_payment>(_refinepay.get<fine_payment>(id));
            return   RedirectToAction("listfine_payment");
        }



    }
}
