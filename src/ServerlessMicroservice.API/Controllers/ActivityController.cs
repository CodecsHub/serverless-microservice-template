using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public async Task<ActivityResponse> Get(long id)
        {
            return await _activityService.GetAsync(id);
        }

        // GET api/v1/products
        [HttpGet]
        public async Task<ActivityResponse> Get()
        {
            return await _activityService.GetAllAsync();
        }

        // POST api/v1/products
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task Post([FromBody]ActivityRequest productRequest)
        {
            await _activityService.AddAsync(productRequest);
        }
    }
}