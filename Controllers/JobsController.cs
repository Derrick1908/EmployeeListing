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
    public class JobsController : ApiController
    {
        /// <summary>
        /// Gets the Job Listing of All the Jobs based on the Search Criteria
        /// </summary>
        /// <param name="listRequest">Search Criteria based on which to List the Jobs.</param>
        /// <returns></returns>
        // GET: api/Jobs/
        [Authorize(Roles = "SuperAdmin, Admin, User")]//This method is accessible For all types of role  
        public IHttpActionResult GetJobViewModel(ListRequest listRequest)
        {
            ListResponse jobResponse = new ListResponse();
            List<JobViewModel> job = null;
            using (var emp = new JobEntities())
            {
                job = emp.JOBS.Where(j => j.JOBDESCRIPTION.Contains(listRequest.q))
                    .Select(j => new JobViewModel()
                    {
                        id = j.JOBID,
                        title = j.JOBTITLE,
                        description = j.JOBDESCRIPTION,
                        locationId = j.LOCATIONID,
                        departmentId = j.DEPARTMENTID,
                        closingDate = j.CLOSINGDATE,
                        postedDate = j.CLOSINGDATE

                    }).ToList();
                if (listRequest.locationId != null)
                    job = job.Where(j => j.locationId == listRequest.locationId).ToList();

                if (listRequest.departmentId != null)
                    job = job.Where(j => j.departmentId == listRequest.departmentId).ToList();

            }
            jobResponse.total = job.Count;
            jobResponse.data = job;
            if (jobResponse == null)
                return NotFound();

            return Ok(jobResponse);
        }

        /// <summary>
        /// Gets the Job Listing of a Particular Job whose Id is mentioned
        /// </summary>
        /// <param name="id">Job id</param>
        /// <returns>Job Details of that Particular Job</returns>
        // GET: api/Jobs/5
        [ResponseType(typeof(JobViewModel))]
        [Authorize(Roles = "SuperAdmin, Admin, User")]//This method is accessible For all types of role
        public IHttpActionResult GetJobViewModel(int id)
        {
            JobViewModel job = null;
            using (var emp = new JobEntities())
            {
                job = emp.JOBS.Where(j => j.JOBID == id)
                    .Select(j => new JobViewModel()
                    {
                        id = j.JOBID,
                        title = j.JOBTITLE,
                        description = j.JOBDESCRIPTION,
                        location = emp.LOCATIONs.Where(l => l.LOCATIONID == j.LOCATIONID).Select(loc => new LocationViewModel()
                        {   
                            id = loc.LOCATIONID,
                            title = loc.LOCATIONNAME,
                            city = loc.LOCATIONCITY,
                            state = loc.LOCATIONSTATE,
                            country = loc.LOCATIONCOUNTRY,
                            zip = loc.LOCATIONZIP

                        }).FirstOrDefault(),
                        department = emp.DEPARTMENTs.Where(d => d.DEPARTMENTID == j.DEPARTMENTID).Select(dept => new DepartmentViewModel()
                        {
                            id = dept.DEPARTMENTID,
                            title = dept.DEPARTMENTNAME

                        }).FirstOrDefault(),
                        closingDate = j.CLOSINGDATE,
                        postedDate = j.CLOSINGDATE

                    }).FirstOrDefault();
            }
            if (job == null)
                return NotFound();
            
            return Ok(job);
        }

        /// <summary>
        /// Updates the Details of a Particular Job whose Id is mentioned with the New Details
        /// </summary>
        /// <param name="id">Id of Job Listing to be updated</param>
        /// <param name="job">New Job Details to be updated</param>
        /// <returns></returns>
        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        [Authorize(Roles = "SuperAdmin")]//This method is accessible only for SuperAdmin
        public IHttpActionResult PutJobViewModel(int id, JobViewModel job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            
            using (var emp = new JobEntities())
            {
                var existingJob = emp.JOBS.Where(j => j.JOBID == id).FirstOrDefault();

                if(existingJob != null)
                {
                    existingJob.JOBTITLE = job.title;
                    existingJob.JOBDESCRIPTION = job.description;
                    existingJob.LOCATIONID = job.locationId;
                    existingJob.DEPARTMENTID = job.departmentId;
                    existingJob.CLOSINGDATE = job.closingDate;
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
        /// Used to Create a New Job that will be listed in the Job Listings
        /// </summary>
        /// <param name="job">Details of the Job to be Listed</param>
        /// <returns></returns>
        // POST: api/Jobs
        [ResponseType(typeof(JobViewModel))]
        [Authorize(Roles = "SuperAdmin")]//This method is accessible only for SuperAdmin
        public IHttpActionResult PostJobViewModel(JobViewModel job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            using (var emp = new JobEntities())
            {
                emp.JOBS.Add(new JOB()
                {
                    JOBTITLE = job.title,
                    JOBDESCRIPTION = job.description,
                    LOCATIONID = job.locationId,
                    DEPARTMENTID = job.departmentId,
                    CLOSINGDATE = job.closingDate
                });
                emp.SaveChanges();
            }
            return Ok();
        }
       
    }
}