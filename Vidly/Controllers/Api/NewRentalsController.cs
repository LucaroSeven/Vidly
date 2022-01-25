using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies.Where(
                m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (customer.IsDelinquent)
                return BadRequest("The Customer is Delinquent");

            int moviesCanRent = customer.LimitOfMoviesRented - customer.MoviesRented;

            if (movies.Count > moviesCanRent)
                return BadRequest("Limit of movies exceeded.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                Rental rental = new Rental
                {
                    DateRented = DateTime.Now,
                    Customer = customer,
                    Movie = movie
                };
                movie.NumberAvailable--;
                _context.Rentals.Add(rental);

            }
            customer.MoviesRented += movies.Count;

            _context.SaveChanges();

            return Ok();
        }

        /*[HttpGet]
        public IHttpActionResult GetNewRentals()
        {

            var newRentalsDto = _context.Rentals.Include(r => r.Customer)
                .Where(r => r.DateReturned == null)
                .ToList();

            return Ok(newRentalsDto);
        }*/

        [HttpGet]
        public IHttpActionResult GetNewRentals(int customerId)
        {

            var newRentalsDto = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(r => r.Customer.Id == customerId)
                .OrderByDescending(r => r.DateRented)
                .ToList();

            return Ok(newRentalsDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateNewRentals(int id)
        {
            Rental rental = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .SingleOrDefault(m => m.Id == id);

            if (rental == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (rental.DateReturned == null)
            {
                rental.DateReturned = DateTime.Now;
                rental.Movie.NumberAvailable++;
                rental.Customer.MoviesRented--;
                _context.SaveChanges();
            }


            return Ok();
        }

    }
}
