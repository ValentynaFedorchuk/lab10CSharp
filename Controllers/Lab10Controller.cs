using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication10.Controllers
{
    public class Lab10Controller : Controller
    {
        // GET: Lab10
        public ActionResult ListOfDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using (var db = new HospitalEntities()) 
            { 
                doctors = db.Doctors.OrderByDescending(x => x.Age)
                    .ThenBy(x => x.FullName).ToList();
            }
            return View(doctors);
        }

        [HttpGet]
        public ActionResult DoctorDetails(Guid doctorId) 
        {
            Doctor model = new Doctor();
            using (var db = new HospitalEntities()) 
            {
                model = db.Doctors.Find(doctorId);
            }
            return View(model);
        }
    }
}