using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Domain.Contracts;
using ServerlessMicroservice.Infrastructure.Interfaces;
using System.Net;

namespace ServerlessMicroservice.API.Controllers
{

    /// <summary>
    ///
    /// </summary>
    public class ActivityController : V1Controller
    {
        private readonly IActivityService _activityService;

        /// <summary>
        ///
        /// </summary>
        /// <param name="activityService"></param>
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // GET api/v1/products/{id}
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseCache(Duration = 20)]
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ActivityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long id)
        {

            //try
            //{
               // Activity activity = null;

                // Get the requested ETag
                string requestETag = "";
                if (Request.Headers.ContainsKey("If-None-Match"))
                {
                    requestETag = Request.Headers["If-None-Match"].First();

                }




                var output = await _activityService.GetByIdAsync(id);

                // If no contact was found, then return a 404
                if (output == null)
                {
                    return NoContent();
                }
                //string test = output.Data.
                // Construct the new ETag
              // var responseETag = 

                // Return a 304 if the ETag of the current record matches the ETag in the "If-None-Match" HTTP header
               // if (Request.Headers.ContainsKey("If-None-Match") && responseETag == requestETag)
                //{
                //    return StatusCode((int)HttpStatusCode.NotModified);
                //}

               // Response.Headers.Add("ETag", responseETag);
                return Ok(output);

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex);
            //}
         }

        // GET api/v1/products
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 1800)]
        [HttpGet]
        [ProducesResponseType(typeof(ActivityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var output = await _activityService.GetAllAsync();

                if (output == null)
                {
                    return NoContent();
                }


                return Ok(output);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // POST api/v1/products
        /// <summary>
        ///
        /// </summary>
        /// <param name="activityRequest"></param>
        /// <returns></returns>
        [HttpPost]
        //[ProducesResponseType(201, Type = typeof(Activity))]
        [ProducesResponseType(typeof(ActivityResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Post([FromBody]ActivityRequest activityRequest)
        {

            await _activityService.AddAsync(activityRequest);


            //try
            //{
            //    var output = await _activityService.AddAsync(activityRequest);
            //    if (output == null)
            //    {
            //        return NotFound();
            //    }

            //    return Ok(output);
            //}
            //catch (Exception)
            //{
            //    return BadRequest();
            //}
        }

    }
}