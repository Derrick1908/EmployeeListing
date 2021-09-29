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
    public class DepartmentsController : ApiController
    {
        /// <summary>
        /// Gets the Department Details of a Particular Office Department
        /// </summary>
        /// <param name="id">Id of the Particular Office Department</param>
        /// <returns></returns>
        // GET: api/Departments/5
        [ResponseType(typeof(DepartmentViewModel))]
        [Authorize(Roles = "SuperAdmin, Admin, User")]//This method is accessible For all types of role
        public IHttpActionResult GetDepartmentViewModel(int id)
        {
            DepartmentViewModel dept = null;
            using (var emp = new JobEntities())
            {
                dept = emp.DEPARTMENTs.Where(d => d.DEPARTMENTID == id)
                    .Select(d => new DepartmentViewModel()
                    {
                        id = d.DEPARTMENTID,
                        title = d.DEPARTMENTNAME                     
                    }).FirstOrDefault();
            }
            if (dept == null)
                return NotFound();

            return Ok(dept);
        }

        /// <summary>
        /// Updates an Existing Department of the Office
        /// </summary>
        /// <param name="id">Id of the Department to be Updated</param>
        /// <param name="dept">New Department Details to be Updated</param>
        /// <returns></returns>
        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        [Authorize(Roles = "SuperAdmin, Admin")]//This method is accessible only for SuperAdmin & Admin
        public IHttpActionResult PutDepartmentViewModel(int id, DepartmentViewModel dept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            using (var emp = new JobEntities())
            {
                var existingDepartment = emp.DEPARTMENTs.Where(d => d.DEPARTMENTID == id).FirstOrDefault();

                if (existingDepartment != null)
                {
                    existingDepartment.DEPARTMENTNAME = dept.title;
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
        /// Adds a New Department for the Office
        /// </summary>
        /// <param name="dept">Details of the Department to be Added</param>
        /// <returns></returns>
        // POST: api/Departments
        [ResponseType(typeof(DepartmentViewModel))]
        [Authorize(Roles = "SuperAdmin, Admin")]//This method is accessible only for SuperAdmin & Admin
        public IHttpActionResult PostDepartmentViewModel(DepartmentViewModel dept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            using (var emp = new JobEntities())
            {
                emp.DEPARTMENTs.Add(new DEPARTMENT()
                {
                    DEPARTMENTNAME = dept.title
                });
                emp.SaveChanges();
            }
            return Ok();
        }
       
    }
}