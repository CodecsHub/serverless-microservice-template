﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerlessMicroservice.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class V1Controller : ControllerBase
    {
    }
}