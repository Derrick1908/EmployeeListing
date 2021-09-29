using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeListing.Models;
using EmployeeListing.Models.ViewModels;

namespace EmployeeListing.Controllers
{
    public class LocationsController : ApiController
    {
        /// <summary>
        /// Gets the Location Details of a Particular Office Location
        /// </summary>
        /// <param name="id">Id of the Particular Office Location</param>
        /// <returns></returns>
        // GET: api/Locations/5
        [ResponseType(typeof(LocationViewModel))]
        [Authorize(Roles = "SuperAdmin, Admin, User")]//This method is accessible For all types of role
        public IHttpActionResult GetLocationViewModel(int id)
        {
            LocationViewModel loc = null;
            using (var emp = new JobEntities())
            {
                loc = emp.LOCATIONs.Where(l => l.LOCATIONID == id)
                    .Select(l => new LocationViewModel()
                    {
                        id = l.LOCATIONID,
                        title = l.LOCATIONNAME,
                        city = l.LOCATIONCITY,
                        state = l.LOCATIONSTATE,
                        country = l.LOCATIONCOUNTRY,
                        zip = l.LOCATIONZIP
                    }).FirstOrDefault();
            }
            if (loc == null)
                return NotFound();

            return Ok(loc);
        }

        /// <summary>
        /// Updates an Existing Office Location
        /// </summary>
        /// <param name="id">Id of the Office Location to be Updated</param>
        /// <param name="loc">New Location Details to be Updated</param>
        /// <returns></returns>
        // PUT: api/Locations/5
        [ResponseType(typeof(void))]
        [Authorize(Roles = "SuperAdmin, Admin")]//This method is accessible only for SuperAdmin & Admin
        public IHttpActionResult PutLocationViewModel(int id, LocationViewModel loc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            using (var emp = new JobEntities())
            {
                var existingLocation = emp.LOCATIONs.Where(l => l.LOCATIONID == id).FirstOrDefault();

                if (existingLocation != null)
                {
                    existingLocation.LOCATIONNAME = loc.title;
                    existingLocation.LOCATIONCITY = loc.city;
                    existingLocation.LOCATIONSTATE = loc.state;
                    existingLocation.LOCATIONCOUNTRY = loc.country;
                    existingLocation.LOCATIONZIP = loc.zip;                    
                    emp.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        /// <summary>
        /// Adds a New Location for the Office
        /// </summary>
        /// <param name="loc">Details of the Office Location</param>
        /// <returns></returns>
        // POST: api/Locations
        [ResponseType(typeof(LocationViewModel))]
        [Authorize(Roles = "SuperAdmin, Admin")]//This method is accessible only for SuperAdmin & Admin
        public IHttpActionResult PostLocationViewModel(LocationViewModel loc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            using (var emp = new JobEntities())
            {
                emp.LOCATIONs.Add(new LOCATION()
                {
                    LOCATIONNAME = loc.title,
                    LOCATIONCITY = loc.city,
                    LOCATIONSTATE = loc.state,
                    LOCATIONCOUNTRY = loc.country,
                    LOCATIONZIP = loc.zip
                });
                emp.SaveChanges();
            }
            return Ok();
        }

    }
}