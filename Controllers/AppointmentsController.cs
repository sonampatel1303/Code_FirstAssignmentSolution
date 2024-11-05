using Code_FirstAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Code_FirstAssignment.Controllers
{
  
    public class AppointmentsController : Controller
    {
        private readonly MyContext _context;

        public AppointmentsController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var appointments = _context.Appointments.Include(a => a.PatientID).Include(a => a.Doctorid).ToList();
            return View(appointments);
        }

     
        public IActionResult Details(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

      
        public IActionResult Edit(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

      
        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(appointment).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        public IActionResult Create()
        {
            ViewBag.PatientID = new SelectList(_context.Patients, "PatientID", "Name");  // Assuming you have a Patients entity
            ViewBag.Doctorid = new SelectList(_context.Doctors, "Doctorid", "Name");    // Assuming you have a Doctors entity
            return View();
        }

      
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(_context.Patients, "PatientID", "Name");
            ViewBag.Doctorid = new SelectList(_context.Doctors, "Doctorid", "Name");
            return View(appointment);
        }

        
        public IActionResult Delete(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

      
        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }

  
    }

