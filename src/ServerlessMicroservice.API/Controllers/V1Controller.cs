using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerlessMicroservice.API.Controllers
{
    /// <summary>
    ///
    /// </summary>

    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:Apiversion}/[controller]")]
    public abstract class V1Controller : ControllerBase
    {
    }
}