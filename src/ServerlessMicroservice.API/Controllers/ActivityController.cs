using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Infrastructure.Contracts;
using ServerlessMicroservice.Infrastructure.Interfaces;

namespace ServerlessMicroservice.API.Controllers
{


    public class ActivityController : V1Controller
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // GET api/v1/products/{id}
        [HttpGet("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(long id)
        {


                var output = await _activityService.GetAsync(id);




                return Ok(output);


        }

        // GET api/v1/products
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var output = await _activityService.GetAllAsync();

                if (output == null)
                {
                    return NotFound();
                }


                return Ok(output);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // POST api/v1/products
        [ProducesResponseType(201, Type = typeof(Activity))]
        [ProducesResponseType(400)]
        [HttpPost]

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