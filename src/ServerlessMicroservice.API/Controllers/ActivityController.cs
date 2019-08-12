using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Domain.Contracts;
using ServerlessMicroservice.Infrastructure.Interfaces;

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
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ActivityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long id)
        {

            try
            {
                var output = await _activityService.GetByIdAsync(id);

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

        // GET api/v1/products
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
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