﻿using JustInTimeCompany.Models;
using JustInTimeCompany.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JustInTimeCompany.Controllers
{
    public class BookingController : Controller
    {
        private readonly JITCDbContext _dbContext;

        public BookingController([FromServices] JITCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var airports = _dbContext.Airports;
            var path = new FlightPath();
            return View(new FlightSearch(airports, path));
        }

        [HttpPost]
        public IActionResult Search([Bind("Path, Date")]FlightSearch search)
        {
            var paths = _dbContext.Paths
                .Include(p => p.From)
                .Include(p => p.To)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Schedule)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .Include(p => p.FlightInstances)
                .ThenInclude(fl => fl.Bookings)
                .Where(p => (p.FromId == search.Path.FromId || search.Path.FromId == 0) 
                && (p.ToId == search.Path.ToId || search.Path.ToId == 0));

            foreach(var flightpath in paths)
            {
                flightpath.FlightInstances = flightpath.FlightInstances
                .Where(fl => !fl.IsPassed && fl.TakeOff > search.Date)
                .OrderBy(fl => fl.Schedule.TakeOff)
                .ToList();
            }

            return View(paths);
        }

        public IActionResult Book(int id)
        {
            var flight = _dbContext.Flights
                .Include(fl => fl.Aircraft)
                .ThenInclude(ac => ac.Model)
                .ThenInclude(m => m.Engines)
                .ThenInclude(e => e.Engine)
                .Include(fl => fl.Bookings)
                .Include(fl => fl.Path)
                .ThenInclude(fl => fl.From)
                .Include(fl => fl.Path)
                .ThenInclude(fl => fl.To)
                .Include(fl => fl.Schedule)
                .FirstOrDefault(f => f.Id == id);

            //TODO: Récupérer l'id customer du IdentityUser
            return View(new Booking(flight, new Customer()));
        }

        [HttpPost]
        public IActionResult Book([Bind("FlightId, SeatsTaken")]Booking booking)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(booking);
                _dbContext.SaveChanges();
                return RedirectToAction("Success");
            }
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        //Afficher l'historique des réservations
        public IActionResult History()
        {
            var bookings = _dbContext.Bookings.ToList();

            foreach(var booking in bookings)
            {
                booking.Flight = _dbContext.Flights
                    .Include(fl => fl.Path)
                    .ThenInclude(p => p.From)
                    .Include(fl => fl.Path)
                    .ThenInclude(p => p.To)
                    .Include(fl => fl.Schedule)
                    .First(fl => fl.Id == booking.FlightId);
            }

            return View(bookings);
        }

        //Annuler une réservation
        public IActionResult Cancel(int id)
        {
            return RedirectToAction("History");
        }
    }
}
